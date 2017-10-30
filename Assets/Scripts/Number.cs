using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour {

    [SerializeField]
    Text numText;

    int number;

    void Start()
    {
        
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
