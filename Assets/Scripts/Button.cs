using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    private Button[] buttonArray;
    public static GameObject selectedDefender;
    private Text costText;
    private StarController starController;
    private int starCost;

	// Use this for initialization
	void Start ()
	{
	    starController = FindObjectOfType<StarController>();
        starCost = defenderPrefab.GetComponent<Defender>().starCost;
        buttonArray = FindObjectsOfType<Button>();
	    costText = GetComponentInChildren<Text>();
	    if (costText == null)
	    {
	        Debug.LogWarning("Can't find cost text.");
	    }
	    else
	    {
	        DisplayCost();
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    UpdateCostColor();
	}

    private void UpdateCostColor()
    {
        int starsAmount = starController.getStarsAmount();
        if (starsAmount < starCost) //if insufficient stars
        {
            costText.color = Color.red;
        }
        else
        {
            costText.color = Color.green;
        }
    }

    private void DisplayCost()
    {
        costText.text = starCost.ToString();
    }

    void OnMouseDown()
    {
        if (StartGame.isStarted)
        {
            foreach (var thisButton in buttonArray)
            {
                thisButton.GetComponent<SpriteRenderer>().color = Color.black;
            }

            Color color = Color.white;
            GetComponent<SpriteRenderer>().color = color;

            selectedDefender = defenderPrefab;
        }
    }
}
