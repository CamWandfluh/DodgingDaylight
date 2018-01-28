using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour 
{	
	UnityEngine.UI.Text scoreText;

    //TextMesh scoreText2;

    TextMeshProUGUI scoreText2;
     

	void Start () 
	{
		scoreText = gameObject.GetComponentInChildren<UnityEngine.UI.Text>();
        scoreText2 = gameObject.GetComponentInChildren<TextMeshProUGUI>();
	}

	void Update () 
	{
		
	}

	public void SetText(int newScore)
	{
		scoreText2.text = "SCORE: " + newScore;
	}
}
