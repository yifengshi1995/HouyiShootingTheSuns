using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBoard : MonoBehaviour {

    [SerializeField]
    int stage;
    [SerializeField]
    Number[] numbers;

    int[] leftRange;
    int[] rightRange;
    int[] operands;

    void Awake()
    {
        operands = new int[2];
        RangeDetermination();
        NumberInstantiation();
        float length = GetComponent<RectTransform>().rect.height * 2 / 3;
        foreach (Number num in numbers)
            num.GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
    }
	
	void Update ()
    {

    }

    public void RangeDetermination()
    {
        switch (stage)
        {
            case 1:
                leftRange = Enumerable.Range(1, 9).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 2:
                leftRange = Enumerable.Range(10, 10).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 3:
                leftRange = Enumerable.Range(1, 9).Select(x => x * 11).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 4:
                leftRange = Enumerable.Range(10, 90).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 5:
                leftRange = Enumerable.Range(10, 10).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 6:
                leftRange = Enumerable.Range(10, 10).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 7:
                leftRange = Enumerable.Range(10, 10).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 8:
                leftRange = Enumerable.Range(10, 10).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
            case 9:
                leftRange = Enumerable.Range(10, 10).ToArray();
                rightRange = Enumerable.Range(1, 9).ToArray();
                break;
        }
    }

    public void NumberInstantiation()
    {
        numbers[0].SetNumber(leftRange[UnityEngine.Random.Range(0, leftRange.Length)]);
        operands[0] = numbers[0].GetComponent<Number>().GetNumber();

        numbers[1].SetNumber(rightRange[UnityEngine.Random.Range(0, rightRange.Length)]);
        operands[1] = numbers[1].GetComponent<Number>().GetNumber();

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
