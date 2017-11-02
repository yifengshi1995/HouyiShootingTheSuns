//Author: Yifeng Shi
//This class is used by the result screen interations.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    [SerializeField]
    Image[] stars;
    [SerializeField]
    GameObject starPanel;
    [SerializeField]
    Text resultText;
    [SerializeField]
    Sprite filledStar;
    [SerializeField]
    Sprite emptyStar;

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

    //Show how many stars earned based on the performance
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

        foreach (Image star in stars)
        {
            float size = starPanel.GetComponent<RectTransform>().rect.height * 2 / 3;
            star.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
        }
    }
}
