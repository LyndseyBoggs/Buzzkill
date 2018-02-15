using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		SceneManager.LoadScene (1);
		SceneManager.LoadScene (1);
		GameManager.instance.isGameOver = false;
		GameManager.instance.score = 0;
		GameManager.instance.worldSpeed = 1;
		GameManager.instance.scoreOfLastSpeedUp = 0;
	}

	public void MainMenu(){
		GameManager.instance.isGameOver = false;
		SceneManager.LoadScene (0);
	}
}
