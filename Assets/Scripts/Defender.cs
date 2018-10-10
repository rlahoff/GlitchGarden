﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    // originally only used as a tag (other scripts check to see if there is a defender component
    public int starCost = 100;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
