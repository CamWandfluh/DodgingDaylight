using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetController : MonoBehaviour 
{
	public GameObject mineral;

	public int numSpawnPoints = 1;


	// Use this for initialization
	void Start () 
	{
		CreateMineralSpawnPoints ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3(0f, 0.01f, 0f));
	}

	void CreateMineralSpawnPoints()
	{
		for (int i = 1; i <= numSpawnPoints; i++) 
		{
			Vector3 spawnPoint = Random.onUnitSphere * ((transform.localScale.x / 2) + mineral.transform.localScale.y * .5f) + transform.position;
			GameObject newMineral = Instantiate (mineral, spawnPoint, new Quaternion());
			newMineral.transform.parent = gameObject.transform;
		}
	}
}

