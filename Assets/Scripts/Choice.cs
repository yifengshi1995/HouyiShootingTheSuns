using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    [SerializeField]
    Text numText;

    GameObject gameControl;
    int number;

    void Start()
    {
        if (gameControl == null)
        {
            gameControl = GameObject.Find("GameControl");
        }
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

    public void CheckAnswer()
    {
        gameControl.GetComponent<GameControl>().CheckAnswer(int.Parse(numText.text));
    }

    public Text GetText()
    {
        return numText;
    }
}
