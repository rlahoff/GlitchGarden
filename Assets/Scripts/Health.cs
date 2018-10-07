using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DealDamage(float damage)
    {
        health -= damage;
        // TODO if there is a die animation, trigger that instead and have the animation call DestroyObject()
        if (health <= 0)
            DestroyObject();
            
    }

    public void DestroyObject()
    {
        GameObject.Destroy(gameObject);
    }
}
