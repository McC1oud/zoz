using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingSpawner : MonoBehaviour {

    public int stageLemmingCount;
    public int spawnSpeed;
    public GameObject lemming;
	// Use this for initialization
	void Start () {

        StartCoroutine("SpawnStageLemmings");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnStageLemmings()
    {
        for(int i = 0; i < stageLemmingCount; i++)
        {
            Instantiate(lemming);
            yield return new WaitForSeconds(spawnSpeed);
        }
        
    }
}
