using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0 && volume <= 1)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);

        else
        {
            Debug.LogError("Master volume out of range.");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCount - 1 && level >= 0)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level, 1); //use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order.");
        }
    }

    public static bool LevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level);
        bool isLevelUnlocked = levelValue == 1;

        if (level <= SceneManager.sceneCount - 1 && level >= 0)
        {
            return isLevelUnlocked;
        }

        Debug.LogError("Trying to unlock level not in build order.");
        return false;
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1 && difficulty <= 3)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("The difficulty should be between 1 and 3.");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
