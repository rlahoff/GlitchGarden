using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectilePrefab;
    private GameObject projectileParent; // this is the Projectiles gameObject in the Hierarchy
    public GameObject gun;
    private Animator animator;
    private Spawner myLaneSpawner;

    // Use this for initialization
    void Start () {
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        animator = GetComponent<Animator>();

        SetMyLaneSpawner();
    }
	
    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray)
        {
            if (Mathf.Approximately(transform.position.y, spawner.transform.position.y))
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner for my lane " + transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        if (IsAttackerAheadInLane())
            animator.SetBool("isAttacking", true);
        else
            animator.SetBool("isAttacking", false);
    }

    bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;

        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if (transform.position.x < attacker.transform.position.x)
                return true;
        }

        return false;
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.parent = projectileParent.transform;
        projectile.transform.position = gun.transform.position;
    }
}
