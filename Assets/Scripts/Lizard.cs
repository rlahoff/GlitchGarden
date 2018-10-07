using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
[RequireComponent(typeof(Attacker))]

public class Lizard : MonoBehaviour {


//    private Animator anim;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
 //       anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colObject = collision.gameObject;

        if (!colObject.GetComponent<Defender>()) return;

        //Debug.Log("Lizard OnTriggerEnter2D " + collision.name);

        attacker.Attack(colObject);

    }
}
