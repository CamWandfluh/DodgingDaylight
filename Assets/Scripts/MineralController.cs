using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralController : MonoBehaviour 
{
	public int mineralAmount;

	// Use this for initialization
	void Start () 
	{
		mineralAmount = (int)Random.Range (4f, 10f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
