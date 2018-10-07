using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        foreach( GameObject attacker in attackerPrefabs)
        {
            if (IsTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
		
	}

    private bool IsTimeToSpawn(GameObject attacker)
    {
        float meanSpawnDelay = attacker.GetComponent<Attacker>().spawnFrequency;
        float spawnsPerSecond = 1f / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5f; // 5 is number of lanes

        if (Random.value < threshold)
            return true;
        else
            return false;
    }

    private void Spawn(GameObject attacker)  
    {
        if (!attacker) return;

        Instantiate(attacker, transform.position, Quaternion.identity, transform);

        //Debug.Log(SnapToGrid(CalcWorldPoint(Input.mousePosition)));
    }
}
