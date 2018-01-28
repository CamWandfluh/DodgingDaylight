using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpawner : MonoBehaviour {

	public GameObject Moon;

	// Use this for initialization
	void Start () {
		SpawnMoons (2);
	}

	public void SpawnMoons(int numberOfStars)
	{
		for (int i = 1; i <= numberOfStars; i++) 
		{
			Vector3 spawnPosition = Random.onUnitSphere * ((transform.localScale.x/2) + Moon.transform.localScale.y * 0.5f) + transform.position;
			Instantiate (Moon, spawnPosition, new Quaternion());

		}
	}
}
