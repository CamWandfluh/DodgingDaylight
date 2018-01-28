using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	public float maxSize;
	public float growFactor;
	public float waitTime;
	public float positionMultiplier;
    GameObject Camera;

	public ParticleSystem explosion;
	public AudioSource explosionSound;
	public Transform effect;
	public Transform effectSound;

	public GameObject DeathMenu;

	public GameObject gameController;

	// Use this for initialization
	void Start () {
		//transform.position = transform.position + Random.insideUnitSphere * positionMultiplier;
		//Debug.Log (transform.position);
		StartCoroutine (Scale ());
		explosionSound = GetComponent<AudioSource> ();
        Camera = GameObject.FindGameObjectWithTag ("MainCamera");

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

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Moon")) {
			Debug.Log("blow up moon");
			effect.position = other.gameObject.transform.position;
			//effectSound.position = col.gameObject.transform.position;
			explosionSound.Play();
			explosion.Play();
			Destroy(other.gameObject);
		}

        if (other.gameObject.CompareTag("Ship"))
        {
            Debug.Log("blow up Player");
            effect.position = other.gameObject.transform.position;
            //effectSound.position = col.gameObject.transform.position;
            explosionSound.Play();
            explosion.Play();

			Camera.GetComponent<FollowCam>().enabled = false;
			Destroy(other.gameObject);
            Cursor.visible = true;
			Instantiate (DeathMenu);
			CheckScore ();

        }
	}

	void CheckScore ()
	{
		gameController = GameObject.FindWithTag ("GameController");
		int curScore = gameController.GetComponent<GameController> ().GetScore ();
		if (curScore > PlayerPrefs.GetInt("Highscore", 0)) 
		{
			PlayerPrefs.SetInt ("Highscore", curScore);
			//highscore.text = "Highscore: " + curScore.ToString ();
		}
	}
		
}
