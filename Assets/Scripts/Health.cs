using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public float startHealth;
    private float currentHealth;

	// Use this for initialization
	void Start ()
	{
	    currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
	    if (IsDead())
	    {
	        Destroy(gameObject);
	        if (GetComponent<Attacker>())
	        {
	            WinPanel.enemiesKilled++;
	        }
	    }
	}

    public void DecreaseHealth(float damage)
    {
        currentHealth -= damage;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
