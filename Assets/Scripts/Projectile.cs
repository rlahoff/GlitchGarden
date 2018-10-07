using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    // doesn't work because this script isn't on the same object as the sprite renderer
    // private void OnBecameInvisible() { Destroy(gameObject);  }
    // so use shredder instead

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            collision.GetComponent<Health>().DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
