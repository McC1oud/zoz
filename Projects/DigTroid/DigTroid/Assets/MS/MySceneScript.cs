using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneScript : MonoBehaviour {

    public void loadScene1()
    {
        SceneManager.LoadScene("MainMS");

    }

    public void loadScene2()
    {
        SceneManager.LoadScene("MSTechDemo");
        
    }
}
