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
	public ChasingEnemy doge;
	public int peopleStung;
	public Text peopleStungText;
	public int questTime;
	public Text timerText;
	int timeLeft;
	public GameObject gameScene;
	public GameObject victoryScene;
	public bool quest1Complete;
	public bool quest2Complete;
	public bool quest;
	public GameObject cutScene;
	public Camera cam;

	//public float finalScore;
	public float coins;
	public Text coinsText;
	public float distance;
	public Text tDistnace;
	public float gameTimer;
	public Text gTimer;
	public float tempWorldSpeed = .1f;
	public int pLives;
	private bool timerStarted;

	// Use this for initialization
	void Start () {
		//menuManager = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuManager>();
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
		if(!menuManager)
		{
			menuManager = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuManager>();
		}
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
			if (peopleStungText) {
				peopleStungText.text = "People Stung: " + BeeAttack_Melee.killedEnemies;
				if (BeeAttack_Melee.killedEnemies == 25) {
					gameScene.SetActive (false);
					victoryScene.SetActive (true);
					quest1Complete = true;

				}
			}
			if (timerText) {
				if (!timerStarted) {
					StartCoroutine (Timer ());
					timerStarted = true;
				}
				timerText.text = "Time Left: " + timeLeft;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.R)) {
				menuManager.StartGame ();
			}
		}
		if (!scoreText) {
			scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text> ();
		}
		if (!highScoreText) {
			highScoreText = GameObject.FindGameObjectWithTag ("HighScoreText").GetComponent<Text> ();
		}
		if (!coinText) {
			coinText = GameObject.FindGameObjectWithTag ("CoinsText").GetComponent<Text> ();
		}

		if (!timerText) {
			timerText = GameObject.FindGameObjectWithTag ("TimerText").GetComponent<Text> ();
		}
		if (!doge) {
			doge = GameObject.FindObjectOfType<ChasingEnemy> ();
		}
		if (!peopleStungText) {
			peopleStungText = GameObject.FindGameObjectWithTag ("PeopleStung").GetComponent<Text> ();
		}
		/*if(!tDistnace)
		{
			tDistnace = GameObject.FindGameObjectWithTag("DistanceText").GetComponent<Text>();
		}
		if(!gTimer)
		{
			gTimer = GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>();
		}*/
		coinsText.text = "Coins: " + coins;
		distance = score * worldSpeed;
		//tDistnace.text = "Travel distance: " + distance;
		gameTimer += Time.deltaTime;
		//gTimer.text = "Timer: " + Mathf.Round(gameTimer);
		//finalScore = gameTimer + distance + score + coins + BeeAttack_Melee.killedEnemies / 4 *.25;
	}

	public void ContinueGame()
	{
		if (!quest) {
			menuManager.ContinueScreen ();
		} else {
			gameScene.SetActive (false);
			cutScene.SetActive (true);

		}
	}

	/*public void ContinueYes()
	{
		if (pLives > 0) {

			if (pLives > 0) {
				doge = GameObject.FindObjectOfType<ChasingEnemy> ();
				pLives -= 1;
				SceneManager.LoadScene ("FredTest");
				isGameOver = false;
				//score = 0;
				worldSpeed -= 3;
				doge.currentState = ChasingEnemy.States.idle;
				if (worldSpeed < 1) {
					worldSpeed = 1;
				}
				GameManager.instance.isPaused = false;

			}

//			isGameOver = false;
//			worldSpeed = 1;
//			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
//			foreach(GameObject enemy in enemies)
//				GameObject.Destroy(enemy);
//			GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
//			foreach(GameObject projectile in projectiles)
//				GameObject.Destroy(projectile);
//			doge.currentState = ChasingEnemy.States.idle;
//			menuManager.ContinueScreen();
//			audio.Play();
		

			if (pLives == 0 && isGameOver == true) {
				GameOver ();
			}
		}
	}

	public void ContinueNo()
	{
			GameOver();
	}*/

	public void GameOver(){
		isGameOver = true;
		PlayerPrefs.SetInt ("CoinsOwned", totalCoins);
		if (score > highScore) {
			highScore = score;
			highScoreText.text = " High Score: " + highScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
			PlayerPrefs.Save ();
		}
		SceneManager.LoadScene ("GameOver");
	}

	public void Pause(){
		isPaused = !isPaused;
	}

	public IEnumerator Timer(){
		timeLeft = questTime;
		while (timeLeft > 0) {
			timeLeft--;
			yield return new WaitForSeconds (1f);
		}
	}
}
