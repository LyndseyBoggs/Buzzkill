using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

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
	public int coins;
	public Text coinsText;
	public float distance;
	public Text tDistnace;
	public float gameTimer;
	public Text gTimer;
	public float tempWorldSpeed = .1f;
	public int pLives;
	private bool timerStarted;
	private PlayFabStats playFabStats;
	private BeeMovement bee;
	private BeeAttack_Melee beeAtk;

	// Use this for initialization
	void Start () {
		bee = GameObject.FindObjectOfType<BeeMovement> ();
		beeAtk = GameObject.FindObjectOfType<BeeAttack_Melee> ();
		if (!instance) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (instance);
		//menuManager = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuManager>();
		PlayFabStart();
		playFabStats = GetComponent<PlayFabStats>();
		//highScore = PlayerPrefs.GetInt ("HighScore");
		//totalCoins = PlayerPrefs.GetInt ("CoinsOwned");
		//highScoreText.text = " High Score: " + highScore;

	}
	
	// Update is called once per frame
	void Update () {
		if (!bee) {
			bee = GameObject.FindObjectOfType<BeeMovement> ();
		}
		if (!beeAtk) {
			beeAtk = GameObject.FindObjectOfType<BeeAttack_Melee> ();
		}
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
		if (!coinText) {
			coinText = GameObject.FindGameObjectWithTag ("CoinsText").GetComponent<Text> ();
		}
		if (!isGameOver) {
			score++;
			if (scoreText) {
				scoreText.text = "Score: " + score;
			}
			if (coinsText) {
				coinsText.text = "Coins: " + coins;
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


		if (!timerText) {
			if (GameObject.FindGameObjectWithTag ("TimerText")) {
				timerText = GameObject.FindGameObjectWithTag ("TimerText").GetComponent<Text> ();
			}
		}
		if (!doge) {
			doge = GameObject.FindObjectOfType<ChasingEnemy> ();
		}
		if (!peopleStungText) {
			if(GameObject.FindGameObjectWithTag ("PeopleStung"))
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
*/
	public void ContinueNo()
	{
			GameOver();
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
		playFabStats.SavePlayerStats ();
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

	private void PlayFabStart(){

		//Obtain number of extra lives in inventory
		GetUserInventoryRequest invRequest = new GetUserInventoryRequest ();
		PlayFabClientAPI.GetUserInventory (invRequest, InvFound, OnPlayFabError);

		//Find High Score for Player
		GetPlayerStatisticsRequest scoreRequest = new GetPlayerStatisticsRequest ();
		List<string> scoresList = new List<string> ();
		scoresList.Add ("High Score");
		scoreRequest.StatisticNames = scoresList;
		PlayFabClientAPI.GetPlayerStatistics (scoreRequest, ScoreFound, OnPlayFabError);

		//Find amount of coins owned by the player

	}

	private void InvFound(GetUserInventoryResult result){
		for (int i = 0; i < result.Inventory.Count; i++) {
			if (result.Inventory [i].DisplayName == "Extra Life") {
				pLives = result.Inventory [i].RemainingUses.Value;
			}
			if (result.Inventory [i].DisplayName == "Golden Wings") {
				ConsumeItemRequest shieldRequest = new ConsumeItemRequest ();
				shieldRequest.ConsumeCount = 1;
				shieldRequest.ItemInstanceId = result.Inventory [i].ItemInstanceId;
				PlayFabClientAPI.ConsumeItem (shieldRequest, StartWithShield, OnPlayFabError);
			}
			if (result.Inventory [i].DisplayName == "Double Coins") {
				ConsumeItemRequest doubleRequest = new ConsumeItemRequest ();
				doubleRequest.ConsumeCount = 1;
				doubleRequest.ItemInstanceId = result.Inventory [i].ItemInstanceId;
				PlayFabClientAPI.ConsumeItem (doubleRequest, StartWithDouble, OnPlayFabError);
			}
		}
		result.VirtualCurrency.TryGetValue ("GC", out totalCoins);
		Debug.Log (totalCoins);
	}

	private void ScoreFound (GetPlayerStatisticsResult result){
		highScore = result.Statistics [0].Value;
		highScoreText.text = ("High Score: " + highScore);
	}

	private void OnPlayFabError(PlayFabError error){
		error.GenerateErrorReport ();
	}

	private void StartWithShield(ConsumeItemResult result){
		bee.hasShield = true;
		bee.shieldSprite.SetActive (true);
		Debug.Log ("Starting with shield. You have " + result.RemainingUses + " uses left.");
	}
		
	private void StartWithDouble(ConsumeItemResult result){
		beeAtk.Dtimer = 10;
		beeAtk.hasCoin = true;
		Debug.Log("Stating with double coins. You have " + result.RemainingUses + " uses left.");
	}
}
