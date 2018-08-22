using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingRays : MonoBehaviour {

    private Vector3 newLocation;

    public float gravityVal = 0.16f;
    public float walkSpeed;

    public bool grounded = false;

    private RaycastHit hitDown;
    private RaycastHit hitLeft;
    private RaycastHit hitRight;
    private RaycastHit hitUp;

    private bool xDirection = true;

    //public GameObject rightCollider;
    //public GameObject leftCollider;

    public GameObject troidianModel;



    void Start () {

        //rightCollider.transform.GetComponent<LemmingFlipDirection>().sendAFlipMessage += flipDirections;

        //leftCollider.transform.GetComponent<LemmingFlipDirection>().sendAFlipMessage += flipDirections;

        //this.leftCollider.transform.GetComponent<BoxCollider>().enabled = false;

        troidianModel = this.gameObject.transform.GetChild(0).gameObject;

    }
	
	
	void Update () {

        BuildCollisionData();

        if(transform.position.x + 0.2f >= hitRight.point.x)
        {
            xDirection = false;
            troidianModel.transform.Rotate(0,180,0);
        }

        if (transform.position.x - 0.2f <= hitLeft.point.x)
        {
            xDirection = true;
            troidianModel.transform.Rotate(0, 180, 0);
        }

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

        Vector3 rightOrigin = transform.position; rightOrigin.y = rightOrigin.y + 0.5f;
        rightOrigin.y -= 0.1f;

        if (Physics.Raycast(rightOrigin, Vector3.right, out hitRight, 500))
        {
            Debug.DrawLine(rightOrigin, hitRight.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(rightOrigin, hitRight.point, Color.red);
        }

        Vector3 leftOrigin = transform.position; leftOrigin.y = leftOrigin.y + 0.5f;
        leftOrigin.y -= 0.1f;

        if (Physics.Raycast(leftOrigin, Vector3.left, out hitLeft, 500))
        {
            Debug.DrawLine(leftOrigin, hitLeft.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(leftOrigin, hitLeft.point, Color.red);
        }


    }
    /*
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
*/
}
