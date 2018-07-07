using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PPrefsMgr : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_"; // level_unlocked_0, level_unlocked_1, etc.

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0 && volume <= 1)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("master volume out of range: " + volume);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings)
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);    // 1 is true
        else
            Debug.LogError("level out of range: " + level);
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings)
        {
            return (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1);    // 1 is true
        }
        else
        {
            Debug.LogError("level out of range: " + level);
            return false;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1 && difficulty <= 3)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("difficulty out of range (0 to 1): " + difficulty);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
