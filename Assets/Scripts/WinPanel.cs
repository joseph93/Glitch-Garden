using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    public GameObject levelStatistics1, levelStatistics2, winText;
    private GameTimer gameTimer;

    public static int starsGained = 0;
    public static int starsSpent = 0;
    public static int enemiesKilled = 0;

	// Use this for initialization
	void Start ()
	{
	    gameTimer = FindObjectOfType<GameTimer>();

	    DisplayWinPhrase();

	    DisplayStatistics();
	}

    private void DisplayWinPhrase()
    {
        winText.GetComponent<Text>().text = "You beat " + SceneManager.GetActiveScene().name + "!";
    }

    private void DisplayStatistics()
    {
        levelStatistics1.GetComponent<Text>().text = "Stars gained: " + starsGained + "\nStars spent: " + starsSpent;
        levelStatistics2.GetComponent<Text>().text = "Enemies killed: " + enemiesKilled + "\nElapsed time: " +
                                                     gameTimer.levelTimer + " sec";
    }

    // Update is called once per frame
	void Update () {
	
	}
}
