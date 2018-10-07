using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Attacker : MonoBehaviour {

    //[Range(-1f, 1.5f)] public 
    float speed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (!currentTarget)
            animator.SetBool("isAttacking", false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + "  OnTriggerEnter2D");
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // called from the animator during attack
    public void StrikeTarget(float damage)
    {
        Debug.Log(name + "  StrikeTarget " + damage);

        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health) health.DealDamage(damage);
        }
    }

    // puts the attacker in attack animation mode
    public void Attack(GameObject target)
    {
        currentTarget = target;
        GetComponent<Animator>().SetBool("isAttacking", true);
    }
}
