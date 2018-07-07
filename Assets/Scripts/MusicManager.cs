using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusic;

    AudioSource audioSource;

    // this causes the music manager to persist accross levels
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //the following three functions replace the depracated private void OnLevelWasLoaded(int level)
    void OnEnable()
    {
        //Tell our 'OnLevelLoaded' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelLoaded' function to stop listening for a scene change as soon as this script is disabled. 
        // Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (levelMusic[scene.buildIndex])
        {
            audioSource.clip = levelMusic[scene.buildIndex];
            audioSource.loop = true;
            audioSource.volume = PPrefsMgr.GetMasterVolume();
            audioSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
