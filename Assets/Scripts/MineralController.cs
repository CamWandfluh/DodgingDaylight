using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralController : MonoBehaviour 
{
	private float xRotationAmount;
	private float yRotationAmount;
	private float zRotationAmount;

	public GameObject gameController;

	void Start () 
	{
		xRotationAmount = Random.Range (0f, 1f);
		yRotationAmount = Random.Range (0f, 1f);
		zRotationAmount = Random.Range (0f, 1f);

		gameController = GameObject.FindWithTag ("GameController");
	}

	void Update () 
	{
		gameObject.GetComponent<MeshFilter> ().transform.Rotate (xRotationAmount, yRotationAmount, zRotationAmount, Space.Self);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			gameController.GetComponent<GameController> ().IncrementScore ();
			other.GetComponent<AudioSource> ().Play ();
            Destroy(gameObject);
        }
    }


}
