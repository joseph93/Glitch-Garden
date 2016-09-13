using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarController : MonoBehaviour {

    private int starsAmount = 150;

    public enum Status
    {
        SUCCESS,
        FAILURE
    };

	// Use this for initialization
	void Start () {
	    UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    private void UpdateDisplay()
    {
        GetComponent<Text>().text = starsAmount.ToString();
    }

    public void AddStars(int amount)
    {
        starsAmount += amount;
        WinPanel.starsGained += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (starsAmount >= amount)
        {
            starsAmount -= amount;
            WinPanel.starsSpent += amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
        
    }

    public void removeAllStars()
    {
        starsAmount = 0;
    }

    public int getStarsAmount()
    {
        return starsAmount;
    }
}
