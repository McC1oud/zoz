using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_TechGUI : MonoBehaviour
{
    public GameObject worldScript;

    private static string[] fillTypeNames = { "Filled", "Empty" };
    private static string[] radiusNames = { "0", "1", "2", "3", "4", "5" };
    private static string[] stencilNames = { "Square", "Circle" };

    private int afillTypeIndex = 1, aradiusIndex = 2, astencilIndex = 1;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(4f, 4f, 150f, 500f));
        GUILayout.Label("Fill Type");
        afillTypeIndex = GUILayout.SelectionGrid(afillTypeIndex, fillTypeNames, 2);
        GUILayout.Label("Radius");
        aradiusIndex = GUILayout.SelectionGrid(aradiusIndex, radiusNames, 6);
        GUILayout.Label("Stencil");
        astencilIndex = GUILayout.SelectionGrid(astencilIndex, stencilNames, 2);
        GUILayout.EndArea();

        worldScript.GetComponent<M_VoxelMap>().fillTypeIndex = afillTypeIndex;
        worldScript.GetComponent<M_VoxelMap>().radiusIndex = aradiusIndex;
        worldScript.GetComponent<M_VoxelMap>().stencilIndex = astencilIndex;
    }
    
}
