using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 90;

    Slider slider;
    private bool levelWon = false;
    private AudioSource audioSource;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        slider.value = 0f;
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if (slider.value >= levelSeconds && !levelWon)
        {
            levelWon = true;
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length)
            Debug.Log("win!");
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
