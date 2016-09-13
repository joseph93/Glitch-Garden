using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayDifficulty : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    GetComponent<Text>().text = "Difficulty: " + Display();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private string Display()
    {
        float difficulty = PlayerPrefsManager.GetDifficulty();
        string difficultyStr = "";

        if (difficulty == 1)
            difficultyStr = "Easy";

        else if (difficulty == 2)
            difficultyStr = "Medium";

        else if (difficulty == 3)
            difficultyStr = "Hard";

        return difficultyStr;
    }
}
