using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public GameObject projectile;
    private GameObject projectileParent;
    private Animator anim;
    private AttackerSpawner myLaneSpawner;

    void Start()
    {
        FindProjectilesObject();
        anim = GetComponent<Animator>();
        SetMyLaneSpawner();
    }

    void Update()
    {
        if (isAttackerAheadInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void SetMyLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogWarning("Did not find spawner.");
    }

    private bool isAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

    private void FindProjectilesObject()
    {
        projectileParent = GameObject.Find("Projectiles");

        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    public void Fire()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Gun")
            {
                GameObject tempProjectile = Instantiate(projectile, child.position, Quaternion.identity) as GameObject;
                if (tempProjectile != null) tempProjectile.transform.SetParent(projectileParent.transform);
            }
        }
        
    }
}
