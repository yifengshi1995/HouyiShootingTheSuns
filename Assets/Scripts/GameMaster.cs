using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static int stage;
    public static int[] starsEachStage;
    void Start()
    {
        stage = 1;
        starsEachStage = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        DontDestroyOnLoad(this);
    }

    public static int TotalStars()
    {
        if (starsEachStage == null)
        {
            return 0;
        }
        else
        {
            return starsEachStage.Sum();
        }
        
    }
}
