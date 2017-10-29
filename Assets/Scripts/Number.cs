using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour {

    [SerializeField]
    Text numText;

    int number;

    void Awake()
    {
        //numText.fontSize = (int)(GetComponent<RectTransform>().rect.width / 2);
    }

    public void SetNumber(int num)
    {
        number = num;
        numText.text = number.ToString();
    }

    public int GetNumber()
    {
        return number;
    }

    public Text GetText()
    {
        return numText;
    }
}
