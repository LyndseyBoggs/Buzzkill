﻿using System.Collections;
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

	public int coins;
	public Text coinsText;
	public float distance;
	public Text tDistnace;

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
		if (!menuManager) {
			menuManager = GameObject.FindObjectOfType<MenuManager> ();
		}
		//coinText.text = "Max Coins: " + maxCoins;
		coinText.text = "Coins: " + coins;
		distance = score * worldSpeed;
		//tDistnace.text = "Travel distance: " + distance;
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
