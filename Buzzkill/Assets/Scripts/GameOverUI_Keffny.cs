using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI_Keffny : MonoBehaviour
{
	public Text timeAlive;
	public Text distanceTraveled;
	public Text peopleStung;
	public Text coinsCollected;
	public Text maxCoins;
	public Text yourScore;
	public Text yourhighScore;

	// Use this for initialization
	void Start ()
	{
		//timeAlive.text = "Time: " +;
		//distanceTraveled.text = "Distance Traveled: " +;
		peopleStung.text = "People Stung: " + BeeAttack_Melee.killedEnemies;
		coinsCollected.text = "Coins Collected: " + GameManager.instance.coins;
		maxCoins.text = "Max Coins: " + GameManager.instance.maxCoins;
		yourScore.text = "Your Score: " + GameManager.instance.score;
		yourhighScore.text = "High Score: " + GameManager.instance.highScore;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
