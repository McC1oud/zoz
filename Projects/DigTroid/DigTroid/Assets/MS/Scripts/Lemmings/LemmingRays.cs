using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingRays : MonoBehaviour {

    private Vector3 newLocation;

    public float gravityVal = 0.16f;
    public float walkSpeed;

    public bool grounded = false;

    private RaycastHit hitDown;

    private bool xDirection = true;

    public GameObject rightCollider;
    public GameObject leftCollider;



    void Start () {

        rightCollider.transform.GetComponent<LemmingFlipDirection>().sendAFlipMessage += flipDirections;

        leftCollider.transform.GetComponent<LemmingFlipDirection>().sendAFlipMessage += flipDirections;

        this.leftCollider.transform.GetComponent<BoxCollider>().enabled = false;

    }
	
	
	void Update () {

        BuildCollisionData();

        //float _Horiz = Input.GetAxis("Horizontal");

        //newLocation.x += _Horiz * walkSpeed;

        //transform.position = newLocation;

        if (xDirection == true)
        {
             newLocation.x += walkSpeed;

        }
        else
        {
            newLocation.x -= walkSpeed;
           
        }


        if (transform.position.y <= hitDown.point.y + gravityVal)
        {
            grounded = true;
            newLocation.y = hitDown.point.y;
            transform.position = newLocation;
        }

        if (transform.position.y - hitDown.point.y < 0.2f)
        {
            grounded = false;
        }

        if (!grounded)
        {
            newLocation = transform.position;
            
            transform.position = GravityApplication(newLocation);
        }


	}

    Vector3 GravityApplication(Vector3 yVal)
    {
        yVal.y -= gravityVal;
        return yVal;
    }

    private void BuildCollisionData()
    {
        Vector3 originOffset = new Vector3(transform.position.x, transform.position.y + 0.25f, 0);
        if (Physics.Raycast(originOffset, Vector3.down, out hitDown, 500))
        {
            Debug.DrawLine(originOffset, hitDown.point, Color.blue);
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

}
