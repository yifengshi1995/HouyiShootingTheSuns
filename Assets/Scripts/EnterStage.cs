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
        float length = transform.parent.GetComponent<RectTransform>().rect.height * 4 / 5;
        GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
    }
	
	void Update ()
    {
		if (!starChecked)
        {
            if (stage != 0)
                if (GameMaster.starsEachStage[stage - 1] == 3)
                    GetComponent<Image>().color = new Color(1, 1, 0);
            starChecked = true;
        }
	}

    public void LoadStage()
    {
        if (stage != 0)
        {
            GameMaster.stage = stage;
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene("StartMenu");
        }
        
    }
}
