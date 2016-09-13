using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
    private Animator anim;
    public static bool isStarted = false;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartLevel()
    {
        anim.SetBool("isStarted", true);
        isStarted = true;
    }
}
