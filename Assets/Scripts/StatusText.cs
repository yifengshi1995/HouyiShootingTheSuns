//Author: Yifeng Shi
//This class is for indicating the scenario changes based on the number of stars earned.

using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour {

    bool checkStatus;

	void Start ()
    {
        CheckNumberOfStars();
    }

    public void CheckNumberOfStars()
    {
        if (GameMaster.TotalStars() == 27)
        {
            GetComponent<Text>().text = "Star: 27. Houyi managed to shoot all 9 suns!";
        }
        else if (GameMaster.TotalStars() > 23)
        {
            GetComponent<Text>().text = "Star: " + GameMaster.TotalStars() + ". Houyi almost finished his goal!";
        }
        else if (GameMaster.TotalStars() > 14)
        {
            GetComponent<Text>().text = "Star: " + GameMaster.TotalStars() + ". Houyi finished half of the goal!";
        }
        else if (GameMaster.TotalStars() > 0)
        {
            GetComponent<Text>().text = "Star: " + GameMaster.TotalStars() + ". Houyi made his first step!";
        }
        else if (GameMaster.TotalStars() == 0)
        {
            GetComponent<Text>().text = "Star: 0. Houyi begins his journey!";
        }
    }
}
