using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
        loadMusic(0);
        //PlayerPrefsManager.SetMasterVolume(0.5f);
        PlayerPrefsManager.SetDifficulty(2);
	    audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadMusic(int sceneIndex)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[sceneIndex];
        if (thisLevelMusic)
        {
            if (sceneIndex > 0)
            {
                audioSource.clip = thisLevelMusic;
                audioSource.loop = true;
                audioSource.Play();

            }

            else
            {
                audioSource.clip = thisLevelMusic;
                audioSource.loop = false;
                audioSource.Play();
                StartCoroutine(FadeOut(audioSource, 5.5f));
            }
        }

    }

    void OnLevelWasLoaded(int level)
    {
        loadMusic(level);
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }
        
        SceneManager.LoadScene("StartScreen");
        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
