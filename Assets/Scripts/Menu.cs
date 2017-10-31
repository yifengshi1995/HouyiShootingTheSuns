//Author: Yifeng Shi
//Mostly just a scene manager.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    Text[] texts;

    void Start()
    {
        //Adjust text size
        foreach (Text t in texts)
        {
            t.fontSize = (int)(GetComponent<RectTransform>().rect.height / 12);
        }
    }

    public void SelectStage()
    {
        SceneManager.LoadScene("Home");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Title()
    {
        SceneManager.LoadScene("StartMenu");
    }

    //This method is used by a button which is not located in the same panel as other buttons
    //so special size adjustment is required.
    public void HomeToTitle()
    {
        float length = transform.parent.GetComponent<RectTransform>().rect.height * 4 / 5;
        GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
        SceneManager.LoadScene("StartMenu");
    }
}
