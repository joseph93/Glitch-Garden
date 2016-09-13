using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour
{
    private LevelManager levelManager;

	// Use this for initialization
	void Start ()
	{
	    levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        levelManager.loadLevel("Game Over");
    }
}
