//Author: Yifeng Shi
//This class is used by stage selection scene
//to redirect player into specified stages

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour {

    [SerializeField]
    int stage;
    [SerializeField]
    Text starText;

    bool starChecked;

	void Start ()
    {
        //Adjust grid size for resolution independence
        float length = transform.parent.GetComponent<RectTransform>().rect.height * 4 / 5;
        GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);

        //If earned all three stars for this stage, make the grid gold to indicate that
        if (stage != 0)
            if (GameMaster.starsEachStage[stage - 1] == 3)
                GetComponent<Image>().color = new Color(1, 1, 0);
    }

    public void LoadStage()
    {
        if (stage != 0)
        {
            //Used only by the TITLE button in this scene
            GameMaster.stage = stage;
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene("StartMenu");
        }
        
    }
}
