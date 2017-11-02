//Author: Yifeng Shi
//This class is used by stage selection scene
//to redirect player into specified stages

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour {

    [SerializeField]
    int stage;
    [SerializeField]
    Text starText;
    [SerializeField]
    GameObject starPanel;
    [SerializeField]
    GameObject star;

    bool starChecked;

	void Start ()
    {
        //Adjust grid size for resolution independence
        float length = transform.parent.GetComponent<RectTransform>().rect.height * 4 / 5;
        GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);

        //Show how many stars has earned for this stage
        if (stage != 0)
        {
            for (int i = 0; i < GameMaster.starsEachStage[stage - 1]; i++)
            {
                GameObject starObj = Instantiate(star, starPanel.transform);
                float size = starPanel.GetComponent<RectTransform>().rect.height * 4 / 5;
                starObj.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
            }    
        }
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
