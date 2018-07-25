using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingSquares : MonoBehaviour {

    public int arrayResolution_X = 50;
    public int arrayResolution_Y = 50;

    public float nodeDistance;
    public float binaryPointDistance;

    [SerializeField]
    public List<MS_Node> ms_nodes = new List<MS_Node>();

    // Use this for initialization
    void Start () {
        //binaryPointDistance = nodeDistance / 2;

        Vector3 nextPosition = new Vector3(0, 0, 0);

        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;

        Vector3[] verticies = new Vector3[10000];
        int[] tri = new int[3000];

        int counter = 0;
        int vertCounter = 0;

        for (int i = 0; i < arrayResolution_X; i++)
        {
            ms_nodes.Add(new MS_Node(nextPosition, binaryPointDistance));
            nextPosition.x += nodeDistance;

            verticies[vertCounter + 0] = ms_nodes[i].b_one;
            verticies[vertCounter + 1] = ms_nodes[i].b_two;
            verticies[vertCounter + 2] = ms_nodes[i].b_four;
            verticies[vertCounter + 3] = ms_nodes[i].b_eight;

         
            tri[counter] = vertCounter + 0;
            tri[1 + counter] = vertCounter + 1;
            tri[2 + counter] = vertCounter + 2;
            tri[3 + counter] = vertCounter + 0;
            tri[4 + counter] = vertCounter + 2;
            tri[5 + counter] = vertCounter + 3;
            counter += 6;
            vertCounter += 4;
            print(i);
            
        }

        /*verticies[0] = ms_nodes[0].b_one;
        verticies[1] = ms_nodes[0].b_two;
        verticies[2] = ms_nodes[0].b_four;
        verticies[3] = ms_nodes[0].b_eight;


        tri[0] =  0;
        tri[1] =  1;
        tri[2] =  2;
        tri[3] =  0;
        tri[4] =  2;
        tri[5] =  3;
       */




        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = tri;
        
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class MS_Node
{
    public Vector3 nodePositon;
    public Vector3 b_one, b_two, b_four, b_eight;
    
    public MS_Node(Vector3 aNewPos, float spacing)
    {
        nodePositon = aNewPos;
        
        b_one = nodePositon; b_one.x += -spacing; b_one.y += -spacing;

        b_two = b_one; b_two.y += (spacing * 2);
        
        b_four = nodePositon; b_four.x += spacing; b_four.y += spacing;
        
        b_eight = b_four; b_eight.y += (-spacing * 2);
    }
}
