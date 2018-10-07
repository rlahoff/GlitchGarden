using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectilePrefab;
    private GameObject projectileParent; // this is the Projectiles gameObject in the Hierarchy
    public GameObject gun;

    // Use this for initialization
    void Start () {
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
            //projectileParent("Projectiles");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.parent = projectileParent.transform;
        projectile.transform.position = gun.transform.position;
    }
}
