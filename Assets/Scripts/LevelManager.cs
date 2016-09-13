using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void loadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        print("Next level loaded.");
    }

    public void loadPreviousScene()
    {
        SceneManager.LoadScene(PreviousSceneManager.getPreviousScene());
    }
}
