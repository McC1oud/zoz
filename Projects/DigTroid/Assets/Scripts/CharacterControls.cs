using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour {

    public float walkSpeed;
    float rayRange = 2000;
    float characterThickness = 0.6f;
    float xRayLROffestY = 0.5f;

    bool notGrounded = true;
    bool cantMoveLeft;
    bool cantMoveRight;

    RaycastHit hitUp;
    RaycastHit hitDown;
    RaycastHit hitLeft;
    RaycastHit hitRight;

    Vector3 newLocation;
    Vector3 newLocationDebugUp;
    Vector3 newLocationDebugDown;
    Vector3 newLocationDebugLeft;
    Vector3 newLocationDebugRight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float _Horiz = Input.GetAxis("Horizontal");
        float _Vertz = Input.GetAxis("Vertical");

        newLocation = transform.position;
        
        frameRays();

        if (hitDown.point.y < transform.position.y)
        {
            notGrounded = true;
           // print("notGrounded");
        }

        if (notGrounded)
        {
            newLocation = GravityApplication(newLocation);
            if (newLocation.y <= hitDown.point.y)
            {
                notGrounded = false;
                newLocation.y = hitDown.point.y;
                //print("Grounded");
            }
        }

        if(cantMoveLeft && _Horiz < 0)
        {
            _Horiz = 0;
        }

        if (cantMoveRight && _Horiz > 0)
        {
            _Horiz = 0;
        }

        if(_Horiz > 0)
        {
            cantMoveLeft = false;
        }

        if (_Horiz < 0)
        {
            cantMoveRight = false;
        }

        if(hitLeft.point.x + 1  < transform.position.x)
        {
            cantMoveLeft = false;
        }

        if (hitRight.point.x - 1 > transform.position.x)
        {
            cantMoveRight = false;
        }

        newLocation.x += _Horiz * walkSpeed;

        if (newLocation.x <= hitLeft.point.x + characterThickness)
        {
            if (_Horiz != 0)
            {
                Vector3 wallOffset = hitLeft.point;
                wallOffset.y += -xRayLROffestY;
                wallOffset.x += characterThickness;
                newLocation = wallOffset;
                cantMoveLeft = true;
            }
        }

        if (newLocation.x >= hitRight.point.x - characterThickness)
        {
            if (_Horiz != 0)
            {
                Vector3 wallOffset = hitRight.point;
                wallOffset.y += -xRayLROffestY;
                wallOffset.x -= characterThickness;
                newLocation = wallOffset;
                cantMoveRight = true;
            }
        }
        
        transform.position = newLocation;

        if (Input.GetKey(KeyCode.Space))
        {
            
            Vector3 jumpThingy = transform.position;
            jumpThingy.y += 1;
            transform.position = jumpThingy;
        }
    }

    Vector3 GravityApplication(Vector3 yVal)
    {
        yVal.y -= 0.16f;
        return yVal;
    }

    void frameRays()
    {
        newLocationDebugUp = newLocation; newLocationDebugUp.y += rayRange;
        newLocationDebugDown = newLocation; newLocationDebugDown.y += -rayRange;
        newLocationDebugLeft = newLocation; newLocationDebugLeft.x += -rayRange;
        newLocationDebugRight = newLocation; newLocationDebugRight.x += rayRange;

        //UpCast
        if (Physics.Raycast(transform.position, Vector3.up, out hitUp, rayRange))
        {
            Debug.DrawLine(transform.position, hitUp.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(transform.position, newLocationDebugUp, Color.red);
        }

        Vector3 downOrigin = transform.position; downOrigin.y = downOrigin.y + xRayLROffestY;
        //DownCast
        if (Physics.Raycast(downOrigin, Vector3.down, out hitDown, rayRange))
        {
            Debug.DrawLine(downOrigin, hitDown.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(downOrigin, newLocationDebugDown, Color.red);
        }

        //LeftCast
        Vector3 leftOrigin = transform.position; leftOrigin.y = leftOrigin.y + xRayLROffestY;
        if (Physics.Raycast(leftOrigin, Vector3.left, out hitLeft, rayRange))
        {
            Debug.DrawLine(leftOrigin, hitLeft.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(leftOrigin, newLocationDebugLeft, Color.red);
        }

        //RightCast
        Vector3 rightOrigin = transform.position; rightOrigin.y = rightOrigin.y + 0.5f;
        if (Physics.Raycast(rightOrigin, Vector3.right, out hitRight, rayRange))
        {
            Debug.DrawLine(rightOrigin, hitRight.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(rightOrigin, newLocationDebugRight, Color.red);
        }
    }
}
