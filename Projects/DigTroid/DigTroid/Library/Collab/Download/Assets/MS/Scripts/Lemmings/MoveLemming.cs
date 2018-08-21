using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLemming : MonoBehaviour {

    public float speed;
    private float onAHill = 0;
    private bool xDirection = true;

    public GameObject rightCollider;
    public GameObject leftCollider;
    public GameObject b_rightCollider;
    public GameObject b_leftCollider;

    void Start () {
        rightCollider.transform.GetComponent<LemmingFlipDirection>().sendAFlipMessage += flipDirections;
       
        leftCollider.transform.GetComponent<LemmingFlipDirection>().sendAFlipMessage += flipDirections;
      
        this.leftCollider.transform.GetComponent<BoxCollider>().enabled = false;
    }
	
	void Update () {
        if(xDirection == true)
        {
            //this.transform.Translate(new Vector3(speed * Time.deltaTime, onAHill, 0));
            this.transform.position = new Vector3(transform.position.x+speed, transform.position.y, 0);
        }
        else
        {
           // this.transform.Translate(new Vector3(-speed * Time.deltaTime, onAHill, 0));
            this.transform.Translate(new Vector3(-speed * Time.deltaTime, onAHill, 0));
        }
    }


    public void flipDirections()
    {
        
        if (xDirection)
        {
            this.rightCollider.transform.GetComponent<BoxCollider>().enabled = false;
            this.leftCollider.transform.GetComponent<BoxCollider>().enabled = true;
          
            this.xDirection = false;
            print("I flip left");
        }
        else
        {
            this.rightCollider.transform.GetComponent<BoxCollider>().enabled = true;
            this.leftCollider.transform.GetComponent<BoxCollider>().enabled = false;
           
            this.xDirection = true;
            print("I flip right");
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.point);
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
