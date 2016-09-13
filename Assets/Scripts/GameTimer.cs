using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public int levelTimer;
    private Slider slider;
    private Text timerText;
    private float timeLeft;
    private StarController starController;
    private bool levelIsOver = false;

    public GameObject winPanel;
    private MusicManager musicManager;

	// Use this for initialization
	void Start ()
	{
	    starController = FindObjectOfType<StarController>();
	    musicManager = FindObjectOfType<MusicManager>();

	    slider = GetComponent<Slider>();
        if(slider)
	        slider.maxValue = levelTimer;

	    timerText = GetComponent<Text>();
	    if (timerText)
	    {
            timerText.text = levelTimer.ToString();
            timeLeft = levelTimer;
        }
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (StartGame.isStarted)
	    {
	        if (slider)
	        {
	            slider.value += Time.deltaTime;
	            if (slider.value >= slider.maxValue && !levelIsOver)
	            {
	                LevelOver();
	                levelIsOver = true;
	            }
	        }
	        if (timerText)
	        {
	            timeLeft -= Time.deltaTime;
	            timerText.text = timeLeft <= 0 ? "0" : ((int) timeLeft).ToString();
	        }
	    }
	}

    private void LevelOver()
    {
        if(musicManager)
            musicManager.GetComponent<AudioSource>().Stop();

        GetComponent<AudioSource>().Play();
        winPanel.SetActive(true);
        starController.removeAllStars();
        Destroy(GameObject.Find("Defenders"));
        Destroy(GameObject.Find("AttackerSpawners"));
        Destroy(GameObject.Find("Projectiles"));
        print("Level is over.");
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }
}
