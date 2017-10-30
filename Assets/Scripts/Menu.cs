using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    Text[] texts;

    // Use this for initialization
    void Start()
    {
        foreach (Text t in texts)
        {
            t.fontSize = (int)(GetComponent<RectTransform>().rect.height / 12);
        }
    }

    // Update is called once per frame
    void Update()
    {

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
}
