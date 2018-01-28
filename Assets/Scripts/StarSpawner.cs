using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

	public GameObject Star;
    int numStars = 4;

	// Use this for initialization
	void Start () {
        SpawnStars (numStars);
	}

	public void SpawnStars(int numberOfStars)
	{
		for (int i = 1; i <= numberOfStars; i++) 
		{
			Vector3 spawnPosition = Random.onUnitSphere * ((transform.localScale.x/2) + Star.transform.localScale.y * 0.5f) + transform.position;
			Instantiate (Star, spawnPosition, new Quaternion());
		}

	}
}
