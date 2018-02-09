using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public KeyCode pauseButton = KeyCode.P;
	public static GameManager instance;
	public bool isPaused;
	public int score;
	public Text scoreText;
	public bool isGameOver;

	// Use this for initialization
	void Start () {
		if (!instance) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (pauseButton)) {
			isPaused = !isPaused;
		}
		if (isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		if (isPaused) {
			return;
		}
		if (!isGameOver) {
			score++;
			scoreText.text = "Score: " + score;
		}
	}

	public void GameOver(){
		isGameOver = true;
	}
}
