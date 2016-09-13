using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour
{

    private StarController stController;
    public int starCost;

	// Use this for initialization
	void Start ()
	{
	    stController = FindObjectOfType<StarController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStars(int amount)
    {
       stController.AddStars(amount);
    }
    
}
