using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public KeyCode pauseButton = KeyCode.P;
	public static GameManager instance;
	public bool isPaused;
	public int score;
	public Text scoreText;
	public bool isGameOver;
	public int highScore;
	public Text highScoreText;
	public float worldSpeed = 1;
	public int scoreToSpeedUp;
	public float speedIncrement;
	private int scoreOfLastSpeedUp;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("HighScore");
		highScoreText.text = " High Score: " + highScore;
		if (!instance) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (instance);
	}
	
	// Update is called once per frame
	void Update () {
		if ((score - scoreOfLastSpeedUp) > scoreToSpeedUp) {
			worldSpeed += speedIncrement;
			scoreOfLastSpeedUp = score;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
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
			if (scoreText) {
				scoreText.text = "Score: " + score;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (0);
				isGameOver = false;
				score = 0;
			}
			Text finalScoreText = GameObject.FindObjectOfType<Text> ();
			finalScoreText.text = "Your Score: " + score;
		}
		if (!scoreText) {
			scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text>();
		}
		if (!highScoreText) {
			highScoreText = GameObject.FindGameObjectWithTag ("HighScoreText").GetComponent<Text>();
		}
	}

	public void GameOver(){
		isGameOver = true;
		if (score > highScore) {
			highScore = score;
			highScoreText.text = " High Score: " + highScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
			PlayerPrefs.Save ();
		}
		SceneManager.LoadScene (1);
	}
}
