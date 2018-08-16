using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnaBall : MonoBehaviour {

    public GameObject aNBalls;

	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(aNBalls);
        }
		
	}
}
