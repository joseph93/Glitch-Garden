using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{

    public GameObject[] attackers;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (StartGame.isStarted)
	    {
            Invoke("SpawnAttackers", 6f);
        }
	    
	}

    private void SpawnAttackers()
    {
        foreach (GameObject thisAttacker in attackers)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    private bool isTimeToSpawn(GameObject att)
    {
        float meanSpawnDelay = att.GetComponent<Attacker>().seenEverySeconds;
        float spawnsPerSecond = 1/meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float treshold = spawnsPerSecond*Time.deltaTime/5;

        return Random.value < treshold;
    }

    private void Spawn(GameObject att)
    {
        GameObject attacker = Instantiate(att, transform.position, Quaternion.identity) as GameObject;
        if(attacker != null) attacker.transform.SetParent(transform);
    }
}
