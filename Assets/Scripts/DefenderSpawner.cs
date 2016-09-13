using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour
{

    private GameObject defenders;
    private StarController starController;

	// Use this for initialization
	void Start () {
	    defenders = GameObject.Find("Defenders");
	    if (!defenders)
	    {
	        defenders = new GameObject("Defenders");
	    }
	    starController = FindObjectOfType<StarController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private Vector2 CalculateWorldPointOfMouseClick()
    {
        Vector2 worldSpacePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return worldSpacePosition;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float snappedX = Mathf.Round(rawWorldPos.x);
        float snappedY = Mathf.Round(rawWorldPos.y);

        return new Vector2(snappedX, snappedY);
    }

    void OnMouseDown()
    {
        if (Button.selectedDefender)
        {
            int starsCost = Button.selectedDefender.GetComponent<Defender>().starCost;
            StarController.Status status = starController.UseStars(starsCost);
            if (status == StarController.Status.SUCCESS)
            {
                Debug.Log("Successfully used " + starsCost);
                SpawnDefender();
            }
            else
            {
                Debug.Log("Not enough stars.");
            }
        }
    }

    private void SpawnDefender()
    {
        if (Button.selectedDefender)
        {
            Vector2 pos = SnapToGrid(CalculateWorldPointOfMouseClick());
            GameObject defender = Instantiate(Button.selectedDefender, pos, Quaternion.identity) as GameObject;
            if (defender != null) defender.transform.SetParent(defenders.transform);
            
        }
    }
}
