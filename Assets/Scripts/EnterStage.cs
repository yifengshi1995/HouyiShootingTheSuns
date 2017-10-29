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

	// Use this for initialization
	void Awake () {
        float length = transform.parent.GetComponent<RectTransform>().rect.height * 2 / 3;
        GetComponent<RectTransform>().sizeDelta = new Vector2(length, length);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadStage()
    {
        SceneManager.LoadScene(stage.ToString());
    }
}
