using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    // currently only being used as a tag (other scripts check to see if there is a defender component

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + "  OnTriggerEnter2D");
    }
}
