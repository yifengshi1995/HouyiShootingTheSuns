using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBoard : MonoBehaviour {

    [SerializeField]
    Number[] numbers;
    [SerializeField]
    GameControl gameControl;

    int stage;
    int[] leftRange;
    int[] rightRange;
    int[] operands;

    void Start()
    {
        stage = GameMaster.stage;
        operands = new int[2];
        RangeDetermination();
        NumberInstantiation();
        float length = GetComponent<RectTransform>().rect.height * 4 / 5;
        foreach (Number num in numbers)
        {
            num.GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
            num.GetText().fontSize = (int)(num.GetComponent<RectTransform>().rect.width / 2);
        }
           
    }
	
	void Update ()
    {
        
    }

    public void RangeDetermination()
    {
        switch (stage)
        {
            case 0: //Prevent error within the Editor. Will not happen in real gameplay.
            case 1:
                leftRange = Enumerable.Range(1, 10).ToArray(); //1-10, calculate square, problem fixed
                rightRange = Enumerable.Range(1, 10).ToArray(); //placeholder arrays, not used              
                break;
            case 2:
                leftRange = Enumerable.Range(1, 9).ToArray(); //1-9
                rightRange = Enumerable.Range(1, 9).ToArray(); //1-9  
                break;
            case 3:
                leftRange = Enumerable.Range(10, 10).ToArray(); //10-19
                rightRange = Enumerable.Range(1, 9).ToArray(); //1-9
                break;
            case 4:
                leftRange = Enumerable.Range(1, 9).Select(x => x * 11).ToArray(); //multiples of 11
                rightRange = Enumerable.Range(1, 9).ToArray(); //1-9  
                break;
            case 5:
                leftRange = Enumerable.Range(10, 90).ToArray(); //10-99
                rightRange = Enumerable.Range(1, 9).ToArray(); //1-9
                break;
            case 6:
                leftRange = Enumerable.Range(11, 10).ToArray(); //11-20, calculate square, problem fixed
                rightRange = Enumerable.Range(11, 10).ToArray(); //placeholder arrays, not used
                break;
            case 7:
                leftRange = Enumerable.Range(10, 10).ToArray(); //10-19
                rightRange = Enumerable.Range(10, 10).ToArray(); //10-19
                break;
            case 8:
                leftRange = Enumerable.Range(10, 90).ToArray(); //10-99
                rightRange = Enumerable.Range(10, 10).ToArray(); //10-19
                break;
            case 9:
                leftRange = Enumerable.Range(10, 90).ToArray(); //10-99
                rightRange = Enumerable.Range(10, 90).ToArray(); //10-99
                break;
        }
    }

    public void NumberInstantiation()
    {
        if (stage == 1 || stage == 6)
        {
            numbers[0].SetNumber(leftRange[gameControl.GetCurrentQuestionIndex()]);
            operands[0] = numbers[0].GetNumber();

            numbers[1].SetNumber(rightRange[gameControl.GetCurrentQuestionIndex()]);
            operands[1] = numbers[1].GetNumber();
        }
        else
        {
            numbers[0].SetNumber(leftRange[UnityEngine.Random.Range(0, leftRange.Length)]);
            operands[0] = numbers[0].GetComponent<Number>().GetNumber();

            numbers[1].SetNumber(rightRange[UnityEngine.Random.Range(0, rightRange.Length)]);
            operands[1] = numbers[1].GetComponent<Number>().GetNumber();
        }

        numbers[2].GetText().text = "";
    }

    public int[] GetOperands()
    {
        return operands;
    }

    public Number[] GetNumbers()
    {
        return numbers;
    }

    public void NextQuestion()
    {
        NumberInstantiation();
    }
}
