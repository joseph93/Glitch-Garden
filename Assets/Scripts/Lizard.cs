using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	    attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IsAttacking()
    {
        anim.SetBool("isAttacking", true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;

        if (obj.GetComponent<Defender>())
        {
            IsAttacking();
            attacker.Attack(obj);
        }
    }
}
