using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour {

    bool checkStatus;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!checkStatus)
        {
            CheckNumberOfStars();
            checkStatus = true;
        }
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
        else if (GameMaster.TotalStars() > 2)
        {
            GetComponent<Text>().text = "Star: " + GameMaster.TotalStars() + ". Houyi made his first step!";
        }
        else if (GameMaster.TotalStars() == 0)
        {
            GetComponent<Text>().text = "Star: 0. Houyi begins his journey!";
        }
    }
}
