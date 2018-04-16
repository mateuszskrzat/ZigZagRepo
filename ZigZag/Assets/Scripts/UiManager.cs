using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text highScore1;
	public Text highScore2;
	public Text GameScore;

	void Awake() {
		if (instance == null) {
			instance = this;

		}

	}

	// Use this for initialization
	void Start () {
		highScore1.text = "High Score: " + PlayerPrefs.GetInt ("highScore");
	}

	public void GameStart() {
		tapText.GetComponent<Animator> ().Play ("textDown");
		zigzagPanel.GetComponent<Animator> ().Play ("panelUp");
		GameScore.GetComponent<Animator> ().Play ("ScoreAnimation");

	}

	public void GameOver() {
		score.text = PlayerPrefs.GetInt ("score").ToString ();
		highScore2.text = PlayerPrefs.GetInt ("highScore").ToString ();
		GameScore.GetComponent<Animator> ().Play ("ScoreAnimationHide");
		gameOverPanel.SetActive (true);

	}

	public void Reset() {
		SceneManager.LoadScene ("zigzag");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void UpdateScore(int k) {
		GameScore.text = k.ToString ();
	}
}
