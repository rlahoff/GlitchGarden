using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private Button[] buttonArray;

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

	// Use this for initialization
	void Start () {
        buttonArray = FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        selectedDefender = defenderPrefab;
    }
}
