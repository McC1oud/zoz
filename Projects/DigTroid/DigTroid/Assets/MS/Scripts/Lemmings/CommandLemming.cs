using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandLemming : MonoBehaviour {

    public GameObject testy;


    public GameObject mapReference;

    public Material dis;
    public GameObject selectedObject;

    public GameObject currentSelected;
    public GameObject dummyObject;

    void Start() {

    }


    void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.tag == "aToid")
            {
                if (Input.GetMouseButtonDown(0) && currentSelected != null)
                {


                    if (hitInfo.transform.root.gameObject == currentSelected.gameObject)
                    {
                        currentSelected.transform.GetChild(3).gameObject.SetActive(false);
                        currentSelected = hitInfo.transform.root.gameObject;
                        currentSelected.transform.GetChild(3).gameObject.SetActive(true);
                    }

                    if (hitInfo.transform.root.gameObject != currentSelected.gameObject)
                    {
                        currentSelected.transform.GetChild(3).gameObject.SetActive(false);
                        currentSelected = hitInfo.transform.root.gameObject;
                        currentSelected.transform.GetChild(3).gameObject.SetActive(true);
                    }
                }

                else if (Input.GetMouseButtonDown(0))

                {

                    currentSelected = hitInfo.transform.root.gameObject;
                    currentSelected.transform.GetChild(3).gameObject.SetActive(true);

                }


            }

        }


    }



    public void ActivateBlockerToid()
    {
        if (currentSelected == null)
        {
            return;
        }

        SetCharacterNeutral();

        currentSelected.transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;

        //currentSelected.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void DeactivateBlockerToid()
    {
        CheckAvailableSelect();

        bool characterHeading = currentSelected.GetComponent<LemmingRays>().xDirection;
        float headingVal = 0;
        if (characterHeading)
            headingVal = 0;
        if (!characterHeading)
            headingVal = 180;
        currentSelected.transform.GetChild(0).eulerAngles = new Vector3(0, headingVal, 0);

        currentSelected.GetComponent<LemmingRays>().doingUtility = false;

        currentSelected.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;

        //currentSelected.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void DigDown()
    {

        CheckAvailableSelect();
        
        SetCharacterNeutral();
        StartCoroutine("DiggitDown");

    }

    public void DigRight()
    {

        CheckAvailableSelect();

        //SetCharacterNeutral();
        currentSelected.GetComponent<LemmingRays>().gravityVal = 0;
        currentSelected.GetComponent<LemmingRays>().doingUtility = true;
        StartCoroutine("DiggitRight");


    }

    public void SetCharacterNeutral()
    {
        currentSelected.transform.GetChild(0).eulerAngles = new Vector3(0, 90, 0);

        currentSelected.GetComponent<LemmingRays>().doingUtility = true;
        
    }

    public void CheckAvailableSelect()
    {
        if (currentSelected == null)
        {
            return;
        }
    }

    IEnumerator DiggitDown()
    {

        Vector3 whereGoingDown = currentSelected.transform.position;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {

            whereGoingDown.y -= 0.005f;



            currentSelected.transform.root.position = whereGoingDown;
            Vector2 curTrans2D = new Vector2(currentSelected.transform.position.x + 10, (currentSelected.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);
            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();

    }

    IEnumerator DiggitRight()
    {
        Vector3 whereGoingRight = currentSelected.transform.position;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {
           
            whereGoingRight.x += 0.005f;

 

            currentSelected.transform.root.position = whereGoingRight; 
            Vector2 curTrans2D = new Vector2(currentSelected.transform.position.x + 10.1f, (currentSelected.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);
            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        currentSelected.GetComponent<LemmingRays>().gravityVal = 0.025f;
    }
}
