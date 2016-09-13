using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;

    private LevelManager levelManager;
    private MusicManager musicManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        musicManager = FindObjectOfType<MusicManager>();
        
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();

        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        
        Debug.Log("The volume is at: " + PlayerPrefsManager.GetMasterVolume());
        Debug.Log("The difficulty is at: " + PlayerPrefsManager.GetDifficulty());
    }

    void Update()
    {
        musicManager.SetVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.loadLevel("StartScreen");
    }

    public void SetToDefault()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 2;
    }
}
