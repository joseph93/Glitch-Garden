using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;

	// Use this for initialization
	void Start ()
	{
	    attacker = GetComponent<Attacker>();
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Jump()
    {
        anim.SetTrigger("jumpTrigger");
    }

    public void IsAttacking()
    {
        anim.SetBool("isAttacking", true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;

        if (obj.GetComponent<Stone>())
        {
            Jump();
        }

        else if (obj.GetComponent<Defender>())
        {
            IsAttacking();
            attacker.Attack(obj);
        }
    }
}
