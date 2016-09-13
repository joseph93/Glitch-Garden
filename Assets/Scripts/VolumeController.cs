using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public Slider volumeSlider;

	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    GetComponent<Text>().text = Mathf.Floor(volumeSlider.value*100).ToString();

	}
}
