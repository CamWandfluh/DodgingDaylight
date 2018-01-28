using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour {

	// Use this for initialization

	public Text highScore;

	void Start () {
		Cursor.visible = true;
        highScore.text = "Highscore: " + PlayerPrefs.GetInt ("Highscore", 0).ToString ();
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void PlayGame()
	{
		SceneManager.LoadScene ("Default");
	}
}
