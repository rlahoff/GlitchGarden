using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]

public class StarDisplay : MonoBehaviour
{
    private int starCount = 100;
    Text starText;

    public enum Status {FAILURE, SUCCESS};

	// Use this for initialization
	void Start () {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        starCount += amount;
        UpdateDisplay();

    }

    public Status UseStars(int amount)
    {
        if (amount > starCount) 
                return Status.FAILURE;

        starCount -= amount;
        UpdateDisplay();

        return Status.SUCCESS;
    }

    private void UpdateDisplay()
    {
        starText.text = starCount.ToString();
    }
}
