using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWall : MonoBehaviour {

    int wallSuccess;

    public Transform[] walls;

    public Material successMaterial;

    GameObject[] sectorWalls;
    GameObject[] sectorColliders;

    private void Start()
    {
        walls = GetComponentsInChildren<Transform>();
        wallSuccess = Random.Range(0, 5);
        print(walls[wallSuccess]);
        //walls[wallSuccess].GetComponent<Renderer>().material.color = Color.green;
        walls[wallSuccess].GetComponent<MeshRenderer>().material = successMaterial;
        sectorWalls = GameObject.FindGameObjectsWithTag("SectorWall");

        for (int i = 0; i < sectorWalls.Length; i++ )
        {
            if(sectorWalls[i].name != walls[wallSuccess].name)
            {
                sectorWalls[i].GetComponent<SectorController>().enabled = false;
                sectorWalls[i].GetComponent<MeshCollider>().isTrigger = false;
                sectorWalls[i].GetComponent<MeshCollider>().convex = false;
            }
        }

    }
}
