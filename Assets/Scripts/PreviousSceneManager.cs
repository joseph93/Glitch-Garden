using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreviousSceneManager : MonoBehaviour
{
    private static int previousScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static int getPreviousScene()
    {
        return previousScene;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level != (SceneManager.sceneCountInBuildSettings-1))
        {
            previousScene = level;
        }
    }
}
