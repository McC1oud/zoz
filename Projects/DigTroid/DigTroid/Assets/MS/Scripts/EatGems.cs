using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatGems : MonoBehaviour {

    
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gem" )
        {
            print("thing");
            Destroy(other.transform.root.gameObject);
            GameObject thisGuy = GameObject.Find("GameManager");
            thisGuy.GetComponent<GameMan>().gemCount -= 1;

            GameObject.Find("Counter").GetComponent<Text>().text = "" + thisGuy.GetComponent<GameMan>().gemCount;


        }
        
    }
}
