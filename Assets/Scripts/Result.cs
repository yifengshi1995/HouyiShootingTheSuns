using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    [SerializeField]
    Image[] stars;
    [SerializeField]
    Text resultText;
    [SerializeField]
    Sprite filledStar;
    [SerializeField]
    Sprite emptyStar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    public Text GetText()
    {
        return resultText;
    }

    public void SetStars(bool one, bool two, bool three)
    {
        if (one)
            stars[0].sprite = filledStar;
        else
            stars[0].sprite = emptyStar;

        if (two)
            stars[1].sprite = filledStar;
        else
            stars[1].sprite = emptyStar;

        if (three)
            stars[2].sprite = filledStar;
        else
            stars[2].sprite = emptyStar;
    }
}
