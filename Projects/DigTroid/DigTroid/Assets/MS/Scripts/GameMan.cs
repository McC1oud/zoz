using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMan : MonoBehaviour {

    public int gemCount = 20;
    public int secondsCount;

    Text texty;

    // Use this for initialization
    void Start () {
        StartCoroutine("TimerC");

        texty = GameObject.Find("Timer").GetComponent<Text>();
    }
	
	// Update is called once per frame
	public void Update () {
		if (gemCount == 0)
        {
            SceneManager.LoadScene("StartScreen");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }

    IEnumerator TimerC()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            secondsCount++;
            texty.text = "Time: " + secondsCount;
        }
    }
}

