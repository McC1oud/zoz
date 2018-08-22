using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speed;


    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            if (transform.position.y <= 12)
            {
                transform.Translate(new Vector3(0, speed, 0));
            }
        }

        if (Input.GetKey("s"))
        {
            if (transform.position.y >= -6f)
            {
                transform.Translate(new Vector3(0, -speed, 0));
            }


        }

        if (Input.GetKey("a"))
        {
            if (transform.position.x >= -15f)
            {
                transform.Translate(new Vector3(-speed, 0, 0));
            }
        }

        if (Input.GetKey("d"))
        {
            if (transform.position.x <= 15f)
            {
                transform.Translate(new Vector3(speed, 0, 0));
            }
        }

    }
}
