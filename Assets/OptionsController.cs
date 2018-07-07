using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;         // drag into inspector from hierarchy
    public Slider difficultySlider;

    public LevelManager levelManager;
    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        if (!musicManager)
            Debug.LogWarning("MusicManager not found");

        volumeSlider.value = PPrefsMgr.GetMasterVolume();
        difficultySlider.value = PPrefsMgr.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        if (musicManager) musicManager.SetVolume(volumeSlider.value);
    }

    public void ResetToDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }

    public void SaveAndExit()
    {
        PPrefsMgr.SetMasterVolume(volumeSlider.value);
        PPrefsMgr.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("Start");
    }
}
