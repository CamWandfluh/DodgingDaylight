using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	public float maxSize;
	public float growFactor;
	public float waitTime;
	public float positionMultiplier;

	// Use this for initialization
	void Start () {
		//transform.position = transform.position + Random.insideUnitSphere * positionMultiplier;
		//Debug.Log (transform.position);
		StartCoroutine (Scale ());
	}

	IEnumerator Scale()
	{
		// we scale all axis, so they will have the same value, 
		// so we can work with a float instead of comparing vectors
		while(maxSize > transform.localScale.x)
		{
			transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
			yield return null;
		}

	}
}
