﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject parent; // this is the Defenders gameObject in the Hierarchy
    private StarDisplay starDisplay;

    // Use this for initialization
    void Start()
    {
        parent = GameObject.Find("Defenders");

        if (!parent)
        {
            parent = new GameObject("Defenders");
        }

        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }


    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown()  // also works for finger on mobile
    {
        if (!Button.selectedDefender) return;

        // only create defender if there are enough stars to pay for it

        if (starDisplay.UseStars(Button.selectedDefender.GetComponent<Defender>().starCost) == StarDisplay.Status.FAILURE)
            Debug.Log("not enough stars");
        else
            Instantiate(Button.selectedDefender, SnapToGrid(CalcWorldPoint(Input.mousePosition)), Quaternion.identity, parent.transform);
        //Debug.Log(SnapToGrid(CalcWorldPoint(Input.mousePosition)));
    }

    Vector2 CalcWorldPoint(Vector3 mousePosition)
    {
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mousePosition.x, mousePosition.y, distanceFromCamera);

        Vector2 worldPoint = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPoint;
    }

    Vector2 SnapToGrid( Vector2 rawWorldPoint)
    {
        float x = Mathf.Round(rawWorldPoint.x);
        float y = Mathf.Round(rawWorldPoint.y);

        return new Vector2(x, y);
    }
}
