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
	[HideInInspector]
	public int scoreOfLastSpeedUp;
	public int totalCoins;
	public Text coinText;
	public MenuManager menuManager;

	//public float finalScore;
	public float coins;
	public Text coinsText;
	public float distance;
	public Text tDistnace;
	public float gameTimer;
	public Text gTimer;
	public float tempWorldSpeed = .1f;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("HighScore");
		totalCoins = PlayerPrefs.GetInt ("CoinsOwned");
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
			menuManager.Pause ();
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
				menuManager.StartGame ();
			}
		}
		if (!scoreText) {
			scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text>();
		}
		if (!highScoreText) {
			highScoreText = GameObject.FindGameObjectWithTag ("HighScoreText").GetComponent<Text>();
		}
		if (!coinText) {
			coinText = GameObject.FindGameObjectWithTag ("CoinsText").GetComponent<Text> ();
		}
//		if (!menuManager) {
//			menuManager = GameObject.FindObjectOfType<MenuManager> ();
//		}

		if(!coinsText)
		{
			coinsText = GameObject.FindGameObjectWithTag("CurrentCoinText").GetComponent<Text>();
		}
		/*if(!tDistnace)
		{
			tDistnace = GameObject.FindGameObjectWithTag("DistanceText").GetComponent<Text>();
		}
		if(!gTimer)
		{
			gTimer = GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>();
		}*/
		coinText.text = "Banked Coins: " + totalCoins;
		coinsText.text = "Coins: " + coins;
		distance = score * worldSpeed;
		//tDistnace.text = "Travel distance: " + distance;
		gameTimer += Time.deltaTime;
		//gTimer.text = "Timer: " + Mathf.Round(gameTimer);
		//finalScore = gameTimer + distance + score + coins + BeeAttack_Melee.killedEnemies / 4 *.25;
	}

	public void GameOver(){
		isGameOver = true;
		PlayerPrefs.SetInt ("CoinsOwned", totalCoins);
		if (score > highScore) {
			highScore = score;
			highScoreText.text = " High Score: " + highScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
			PlayerPrefs.Save ();
		}
		SceneManager.LoadScene (2);
	}

	public void Pause(){
		isPaused = !isPaused;
	}
}
