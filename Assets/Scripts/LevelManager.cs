using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public float autoLoadNextLevelDelay;

   void Start()
    {
        if (autoLoadNextLevelDelay > 0) // probably only used for the splash screen
            Invoke("LoadNextLevel", autoLoadNextLevelDelay);
        else
            Debug.Log("Auto load next level disabled. Use a positive number in seconds.");
    }

   public void LoadNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int nextScene = scene.buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

  
}
