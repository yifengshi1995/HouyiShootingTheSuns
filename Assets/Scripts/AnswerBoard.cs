using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBoard : MonoBehaviour {

    [SerializeField]
    GameObject questionBoard;
    [SerializeField]
    Choice[] choices;

    int[] operands;
    int answer;
    bool generated;

    void Start ()
    {
        float length = GetComponent<RectTransform>().rect.height * 4 / 5;
        foreach (Choice c in choices)
            c.GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
    }
	
	void Update ()
    {
        if (questionBoard != null && !generated)
        {
            operands = questionBoard.GetComponent<QuestionBoard>().GetOperands();
            answer = operands[0] * operands[1];
            GenerateChoices();
            generated = true;
        }
    }

    public void GenerateChoices()
    {
        int answerIndex = UnityEngine.Random.Range(0, 4);
        int[] numberChoices = new int[4];
        numberChoices[answerIndex] = answer;
        for (int i = 0; i < 4; i++)
        {
            if (answerIndex != i)
            {
                int left = Mathf.Max(1, operands[0] + UnityEngine.Random.Range(- operands[0] / 2, operands[0] / 2));
                int right = Mathf.Max(1, operands[1] + UnityEngine.Random.Range(-operands[1] / 2, operands[1] / 2));
                int wrongAnswer = left * right;
                
                
                while (Array.Exists(numberChoices, x => x == wrongAnswer))
                {
                    if (left <= 3 || right <= 3)
                    {
                        left = Mathf.Max(1, operands[0] + UnityEngine.Random.Range(0, 4));
                        right = Mathf.Max(1, operands[1] + UnityEngine.Random.Range(0, 4));
                    }
                    else
                    {
                        left = Mathf.Max(1, operands[0] + UnityEngine.Random.Range(-operands[0] / 2, operands[0] / 2));
                        right = Mathf.Max(1, operands[1] + UnityEngine.Random.Range(-operands[1] / 2, operands[1] / 2));  
                    }
                    wrongAnswer = left * right;
                }
                

                numberChoices[i] = wrongAnswer;
            }           
        }

        for (int i = 0; i < 4; i++)
        {
            choices[i].SetNumber(numberChoices[i]);
        }
    }

    public void NextQuestion()
    {
        operands = questionBoard.GetComponent<QuestionBoard>().GetOperands();
        answer = operands[0] * operands[1];
        GenerateChoices();
    }

    public int GetAnswer()
    {
        return answer;
    }
}
