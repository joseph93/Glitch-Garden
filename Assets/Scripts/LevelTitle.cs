using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTitle : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    GetComponent<Text>().text = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
