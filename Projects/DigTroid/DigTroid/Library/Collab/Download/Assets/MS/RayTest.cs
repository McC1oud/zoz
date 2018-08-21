using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {


    int layerMask = 1 << 2;

    // Use this for initialization
    void Start () {
       

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up),out hit, 1000))
        {
            Debug.DrawLine(transform.position, hit.point, Color.blue);
           
        }

        else
        {
            Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 100, 0), Color.red);
        }




    }
    
}
