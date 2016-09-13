using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    private Animator anim;
    private float currentSpeed;
    public float seenEverySeconds;
    private GameObject currentTarget;
   
	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	    if (currentTarget == null)
	    {
	        anim.SetBool("isAttacking", false);
	    }
	}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DecreaseHealth(damage);
            }
        }
    }

    private IEnumerator ChangeColor()
    {
        GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 96, 96, 255);
        print("I changed color to " + GetComponentInChildren<SpriteRenderer>().color);
        yield return new WaitForSeconds(1f);

        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        Projectile projectile = obj.GetComponent<Projectile>();

        if (projectile)
        {
            Health health = GetComponent<Health>();
            health.DecreaseHealth(projectile.damage);
            Destroy(obj);

            if (obj.CompareTag("Axe"))
            {
                anim.SetTrigger("hitByAxe trigger");
                StartCoroutine(ChangeColor());
            }
        }
    }
}
