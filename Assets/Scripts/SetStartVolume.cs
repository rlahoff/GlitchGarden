using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            float volume = PPrefsMgr.GetMasterVolume();
            musicManager.SetVolume(volume);
        }
        else
            //this is not a problem if starting in Start level rather than Splash level
            Debug.LogWarning("Music Manager not found, can't set volume.");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
