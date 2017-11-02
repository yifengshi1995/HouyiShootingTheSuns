//Author: Yifeng Shi
//data structure of choices

using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    [SerializeField]
    Text numText;

    [SerializeField]
    GameObject gameControl;

    int number;

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
