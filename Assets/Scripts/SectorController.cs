using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SectorController : MonoBehaviour {

	public GameObject ExitMenu;
	GameObject Camera;

	void Start () {
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
		

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Exiting the Sector");
			Cursor.visible = true;

			Camera.GetComponent<FollowCam>().enabled = false;

			Instantiate (ExitMenu);
		}
	}
}
