using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public int score = 0;
	bool gamePaused = false;
	int round = 1;
	int mineralsInLevel = 0;
	public GameObject player;
	public GameObject StarSpawn;
	public GameObject MoonSpawn;
	GameObject Camera;

	GameObject[] Stars;
	GameObject[] Moons;

	void Start()
	{
		mineralsInLevel = 20 * (2 + (round % 2));
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePause ();
		}
	}

	public void IncrementScore()
	{
		score++;
		player.GetComponentInChildren<HUDController> ().SetText (score);
	}

	public int GetScore()
	{
		return score;
	}

	public void IncrementRound()
	{
		round++;
	}

	public void Quit()
	{
		if (GetScore() > PlayerPrefs.GetInt("Highscore", 0)) 
		{
			PlayerPrefs.SetInt ("Highscore", GetScore());
			Debug.Log ("New HS");
		}

		SceneManager.LoadScene ("Menu");
	}

	public void NextLevel()
	{
		player = GameObject.FindWithTag ("Player");
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		StarSpawn = GameObject.FindGameObjectWithTag("StarSpawn");
		MoonSpawn = GameObject.FindGameObjectWithTag("MoonSpawn");

		Stars = GameObject.FindGameObjectsWithTag ("Star");
		foreach(GameObject objects in Stars){
			Destroy (objects);
		}

		Moons = GameObject.FindGameObjectsWithTag ("Moon");
		foreach(GameObject objects in Moons){
			Destroy (objects);
		}

		IncrementRound ();

		StarSpawn.GetComponent<StarSpawner> ().SpawnStars (round * 4);
		MoonSpawn.GetComponent<MoonSpawner> ().SpawnMoons (2+ (round%2));

		Debug.Log (mineralsInLevel);
		Vector3 Spawn = new Vector3 (0f, 1000f, 0f);

		player.transform.SetPositionAndRotation(Spawn, new Quaternion());


		Debug.Log("Resetting the player");
		Cursor.visible = false;
		Camera.GetComponent<FollowCam>().enabled = true;

		if (score > PlayerPrefs.GetInt("Highscore", 0)) 
		{
			PlayerPrefs.SetInt ("Highscore", score);
			Debug.Log ("New HS");
		}

		GameObject Menu = GameObject.FindGameObjectWithTag ("Exit Screen");
		Destroy (Menu);
	}
		

	public bool canPlayerFinishLevel()
	{
		int levelFinishRequirement = (int) (mineralsInLevel * .55f);

		if (score >= levelFinishRequirement)
		{
			return true;
		}

		return false;
	}

	public void TogglePause()
	{
		gamePaused = !gamePaused;

		if (gamePaused)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}
}


