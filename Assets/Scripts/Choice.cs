using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    [SerializeField]
    Text numText;

    GameObject gameControl;
    int number;

    private void Awake()
    {
        //numText.fontSize = (int)(GetComponent<RectTransform>().rect.width / 2);
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
}
