using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetComponent<SpriteRenderer>().color = new Color(0.5f, 1f, 1f, 0.25f);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 3);
	}
}
