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

    private bool currentlyOnJob = false;


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
        if(!currentlyOnJob)
        {
            
            currentlyOnJob = true;
            CheckAvailableSelect();

            SetCharacterNeutral();
            StartCoroutine("DiggitDown");
        }
       

    }

    public void DigRight()
    {
        if (!currentlyOnJob)
        {
            currentlyOnJob = true;
            CheckAvailableSelect();

            //SetCharacterNeutral();
            currentSelected.GetComponent<LemmingRays>().gravityVal = 0;
            currentSelected.GetComponent<LemmingRays>().doingUtility = true;
            StartCoroutine("DiggitRight");

        }
    }

    public void DigRLeft()
    {

        if (!currentlyOnJob)
        {
            currentlyOnJob = true;
            CheckAvailableSelect();

            //SetCharacterNeutral();
            currentSelected.GetComponent<LemmingRays>().gravityVal = 0;
            currentSelected.GetComponent<LemmingRays>().doingUtility = true;
            StartCoroutine("DiggitLeft");
        }

    }

    public void DigUpLeft()
    {

        if (!currentlyOnJob)
        {
            currentlyOnJob = true;
            CheckAvailableSelect();

            //SetCharacterNeutral();
            currentSelected.GetComponent<LemmingRays>().gravityVal = 0;
            currentSelected.GetComponent<LemmingRays>().doingUtility = true;
            StartCoroutine("DiggitUpLeft");
        }

    }

    public void DigDownLeft()
    {

        if (!currentlyOnJob)
        {
            currentlyOnJob = true;
            CheckAvailableSelect();

            //SetCharacterNeutral();
            currentSelected.GetComponent<LemmingRays>().gravityVal = 0;
            currentSelected.GetComponent<LemmingRays>().doingUtility = true;
            StartCoroutine("DiggitDownLeft");
        }
    }

    public void DigDownRight()
    {

        if (!currentlyOnJob)
        {
            currentlyOnJob = true;
            CheckAvailableSelect();

            //SetCharacterNeutral();
            currentSelected.GetComponent<LemmingRays>().gravityVal = 0;
            currentSelected.GetComponent<LemmingRays>().doingUtility = true;
            StartCoroutine("DiggitDownRight");
        }
    }

    public void DigUpRight()
    {

        if (!currentlyOnJob)
        {
            currentlyOnJob = true;
            CheckAvailableSelect();

            //SetCharacterNeutral();
            currentSelected.GetComponent<LemmingRays>().gravityVal = 0;
            currentSelected.GetComponent<LemmingRays>().doingUtility = true;
            StartCoroutine("DiggitUpRight");
        }
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

        GameObject toolCurrent = currentSelected.gameObject;
        Vector3 whereGoingDown = toolCurrent.transform.position;
        currentlyOnJob = false;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {

            whereGoingDown.y -= 0.005f;

            toolCurrent.transform.root.position = whereGoingDown;
            Vector2 curTrans2D = new Vector2(toolCurrent.transform.position.x + 10, (toolCurrent.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);
            if (toolCurrent.transform.root.position.y < -8f)
            {
                i = 500;
            }

            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        currentlyOnJob = false;
        

    }

    IEnumerator DiggitRight()
    {
        GameObject toolCurrent = currentSelected.gameObject;
        Vector3 whereGoingRight = toolCurrent.transform.position;
        currentlyOnJob = false;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {
           
            whereGoingRight.x += 0.005f;



            toolCurrent.transform.root.position = whereGoingRight; 
            Vector2 curTrans2D = new Vector2(toolCurrent.transform.position.x + 10.1f, (toolCurrent.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);
            if (toolCurrent.transform.root.position.x > 9.9f)
            {
                i = 500;
            }
            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        toolCurrent.GetComponent<LemmingRays>().gravityVal = 0.025f;
       
    }

    IEnumerator DiggitLeft()
    {
        GameObject toolCurrent = currentSelected.gameObject;
        Vector3 whereGoingLeft = toolCurrent.transform.position;
        currentlyOnJob = false;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {

            whereGoingLeft.x -= 0.005f;
            
            toolCurrent.transform.root.position = whereGoingLeft;
            Vector2 curTrans2D = new Vector2(toolCurrent.transform.position.x + 9.9f, (toolCurrent.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);

            if (toolCurrent.transform.root.position.x < -9.9f)
            {
                i = 500;
            }
                yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        toolCurrent.GetComponent<LemmingRays>().gravityVal = 0.025f;
        
    }
    //Diags start here
    IEnumerator DiggitUpLeft()
    {
        GameObject toolCurrent = currentSelected.gameObject;
        Vector3 whereGoingUpLeft = toolCurrent.transform.position;
        currentlyOnJob = false;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {

            whereGoingUpLeft.x -= 0.005f;
            whereGoingUpLeft.y += 0.005f;



            toolCurrent.transform.root.position = whereGoingUpLeft;
            Vector2 curTrans2D = new Vector2(toolCurrent.transform.position.x + 9.9f, (toolCurrent.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);

            if (toolCurrent.transform.root.position.x < -9.8f || toolCurrent.transform.root.position.y > 9.8f)
            {
                i = 500;
            }
            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        toolCurrent.GetComponent<LemmingRays>().gravityVal = 0.025f;

    }

    IEnumerator DiggitDownLeft()
    {
        GameObject toolCurrent = currentSelected.gameObject;
        Vector3 whereGoingDownLeft = toolCurrent.transform.position;
        currentlyOnJob = false;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {

            whereGoingDownLeft.x -= 0.005f;
            whereGoingDownLeft.y -= 0.005f;



            toolCurrent.transform.root.position = whereGoingDownLeft;
            Vector2 curTrans2D = new Vector2(toolCurrent.transform.position.x + 9.9f, (toolCurrent.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);

            if (toolCurrent.transform.root.position.x < -9.8f || toolCurrent.transform.root.position.y < -9.8f)
            {
                i = 500;
            }

            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        toolCurrent.GetComponent<LemmingRays>().gravityVal = 0.025f;

    }

    IEnumerator DiggitUpRight()
    {
        GameObject toolCurrent = currentSelected.gameObject;
        Vector3 whereGoingUpRight = toolCurrent.transform.position;
        currentlyOnJob = false;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {

            whereGoingUpRight.x += 0.005f;
            whereGoingUpRight.y += 0.005f;



            toolCurrent.transform.root.position = whereGoingUpRight;
            Vector2 curTrans2D = new Vector2(toolCurrent.transform.position.x + 10.1f, (toolCurrent.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);
            if (toolCurrent.transform.root.position.x > 9.8f || toolCurrent.transform.root.position.y > 9.8f)
            {
                i = 500;
            }
            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        toolCurrent.GetComponent<LemmingRays>().gravityVal = 0.025f;

    }

    IEnumerator DiggitDownRight()
    {
        GameObject toolCurrent = currentSelected.gameObject;
        Vector3 whereGoingDownRight = toolCurrent.transform.position;
        currentlyOnJob = false;
        int depth = 500;
        for (int i = 0; i < depth; i++)
        {

            whereGoingDownRight.x += 0.005f;
            whereGoingDownRight.y -= 0.005f;



            toolCurrent.transform.root.position = whereGoingDownRight;
            Vector2 curTrans2D = new Vector2(toolCurrent.transform.position.x + 10.1f, (toolCurrent.transform.position.y + 9.3f));

            mapReference.GetComponent<VoxelMap>().DigVoxels(curTrans2D);
            if (toolCurrent.transform.root.position.x > 9.8f || toolCurrent.transform.root.position.y < -9.8f)
            {
                i = 500;
            }
            yield return new WaitForSeconds(0.008f);
        }
        DeactivateBlockerToid();
        toolCurrent.GetComponent<LemmingRays>().gravityVal = 0.025f;

    }
}
