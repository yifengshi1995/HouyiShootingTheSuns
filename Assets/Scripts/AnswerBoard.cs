//Author: Yifeng Shi
//Class handling the panel containing choices

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBoard : MonoBehaviour {

    [SerializeField]
    GameObject questionBoard;
    [SerializeField]
    GameObject gameControl;
    [SerializeField]
    Choice[] choices;

    int[] operands;
    int answer;
    bool generated;

    void Start ()
    {
        //Adjust the grid and text size based on the size of its parent panel
        //to support resolution independence
        float length = GetComponent<RectTransform>().rect.height * 4 / 5;
        foreach (Choice c in choices)
        {
            c.GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
            if (GameMaster.stage < 8)
                c.GetText().fontSize = (int)(c.GetComponent<RectTransform>().rect.width / 2);
            else
                c.GetText().fontSize = (int)(c.GetComponent<RectTransform>().rect.width / 3);
        }
            
    }
	
	void Update ()
    {
        if (!generated)
        {
            operands = questionBoard.GetComponent<QuestionBoard>().GetOperands();
            answer = operands[0] * operands[1];
            GenerateChoices();
            generated = true;
        }
    }

    public void GenerateChoices()
    {
        //Append the correct answer into a random index of the array
        int answerIndex = UnityEngine.Random.Range(0, 4);
        int[] numberChoices = new int[4];
        numberChoices[answerIndex] = answer;
        for (int i = 0; i < 4; i++)
        {
            //If this index is not occupied by the correct answer, generate a wrong answer here
            if (answerIndex != i)
            {
                //If not stage 1 or 6, generate wrong answers by using varied operands
                if (GameMaster.stage != 1 && GameMaster.stage != 6)
                {
                    int left = Mathf.Max(1, operands[0] + UnityEngine.Random.Range(-operands[0] / 2, operands[0] / 2));
                    int right = Mathf.Max(1, operands[1] + UnityEngine.Random.Range(-operands[1] / 2, operands[1] / 2));
                    int wrongAnswer = left * right;

                    //Regenerate a wrong answer if that one was already existing in the array
                    while (Array.Exists(numberChoices, x => x == wrongAnswer))
                    {
                        //If the operand is too small, use the fixed range to prevent infinite loop
                        if (left <= 3 || right <= 3)
                        {
                            left = Mathf.Max(1, operands[0] + UnityEngine.Random.Range(0, 4));
                            right = Mathf.Max(1, operands[1] + UnityEngine.Random.Range(0, 4));
                        }
                        else //Otherwise make the operands vary half of their values
                        {
                            left = Mathf.Max(1, operands[0] + UnityEngine.Random.Range(-operands[0] / 2, operands[0] / 2));
                            right = Mathf.Max(1, operands[1] + UnityEngine.Random.Range(-operands[1] / 2, operands[1] / 2));
                        }
                        wrongAnswer = left * right;
                    }
                    numberChoices[i] = wrongAnswer;
                }
                else //Stage 1 and 6 are fixed questions so use different way
                {
                    int wrongAnswer = answer;
                    while (Array.Exists(numberChoices, x => x == wrongAnswer))
                    {
                        wrongAnswer = wrongAnswer + UnityEngine.Random.Range(0, 6);
                    }
                    numberChoices[i] = wrongAnswer;
                }
            }           
        }

        for (int i = 0; i < 4; i++)
        {
            choices[i].SetNumber(numberChoices[i]);
        }
    }

    public void NextQuestion()
    {
        //Reset the correct answer and regenerate the choices.
        operands = questionBoard.GetComponent<QuestionBoard>().GetOperands();
        answer = operands[0] * operands[1];
        GenerateChoices();
    }

    public int GetAnswer()
    {
        return answer;
    }
}
