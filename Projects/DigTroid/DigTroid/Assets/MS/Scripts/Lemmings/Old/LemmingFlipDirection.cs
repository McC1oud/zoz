using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingFlipDirection : MonoBehaviour {

    public delegate void TimeToFlip();
    public event TimeToFlip sendAFlipMessage;

    private bool cooldownAvailable = true;


    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "stageData")
        {
            print("flipping");
            if(cooldownAvailable)
            {
                sendAFlipMessage();
                StartCoroutine("SendmessageDelay");
            }
            
        }
    }

    IEnumerator SendmessageDelay()
    {
        cooldownAvailable = false;
        yield return new WaitForSeconds(0.1f);
        cooldownAvailable = true;
        

    }
}
