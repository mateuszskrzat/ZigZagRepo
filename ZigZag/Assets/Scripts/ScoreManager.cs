using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public GameObject UiManager;
	public int score;
	public int highScore;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void inrementScore() {
		score++;
		UiManager.GetComponent<UiManager> ().UpdateScore (score);
	}
	public void DiamondIncrement() {
		score += 5;
		UiManager.GetComponent<UiManager> ().UpdateScore (score);
	}
	public void startScore() {
		InvokeRepeating ("inrementScore", 0.1f, 0.5f);

	}
	public void StopScore() {
		CancelInvoke ("inrementScore");
		PlayerPrefs.SetInt ("score", score);

		if (PlayerPrefs.HasKey ("highScore")) {
			if (score > PlayerPrefs.GetInt ("highScore")) {
				PlayerPrefs.SetInt ("highScore", score);
			}
		}
		else {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}
}
