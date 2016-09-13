using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{

    public Slider difficultySlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    DisplayDifficulty();
	}

    public void DisplayDifficulty()
    {
        if (difficultySlider.value == 1)
            GetComponent<Text>().text = "Easy";

        else if(difficultySlider.value == 2)
            GetComponent<Text>().text = "Medium";

        else if (difficultySlider.value == 3)
            GetComponent<Text>().text = "Hard";
    }
}
