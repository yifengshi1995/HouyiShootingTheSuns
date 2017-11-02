//Author: Yifeng Shi
//Containing static variables for recording the game flow.

/*
 * Note: If you run the game in the Unity, you may find  
 * NullReferenceException. That's because the DoNotDestroy 
 * variables are loaded in the title screen, so normal
 * play will not encounter this problem.
 */

using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static int stage; //Stage index that the player will play
    public static int[] starsEachStage; //Stars earned in each stage
    void Start()
    {
        //Prevent reinitialization if go back to the title screen
        if (starsEachStage == null)
            starsEachStage = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        DontDestroyOnLoad(this);
    }

    public static int TotalStars()
    {
        //Calculate total stars that will be used by the scenario indicator
        if (starsEachStage == null)
            return 0;
        else
            return starsEachStage.Sum();
    }
}
