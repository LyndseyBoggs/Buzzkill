using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject pauseButton;

	public GameObject canvas;
	public GameObject optionsMenu;
	public GameObject audioControlsMenu;
	public GameObject soundTracksMenu;
	public GameObject aestheticsMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void StartGame(){
		SceneManager.LoadScene (1);
		GameManager.instance.isGameOver = false;
		GameManager.instance.score = 0;
		GameManager.instance.worldSpeed = 1;
		GameManager.instance.scoreOfLastSpeedUp = 0;
		GameManager.instance.gameTimer = 0;
		GameManager.instance.distance = 0;
		GameManager.instance.coins = 0;
		BeeAttack_Melee.killedEnemies = 0;
		GameManager.instance.isPaused = false;
	}

	public void MainMenu(){
		GameManager.instance.isGameOver = false;
		SceneManager.LoadScene (0);
	}

	public void Pause(){
		GameManager.instance.Pause ();
		pauseMenu.SetActive (!pauseMenu.activeSelf);
		pauseButton.SetActive (!pauseButton.activeSelf);
	}

	public void OptionMenu()
	{
		canvas.SetActive(false);
		optionsMenu.SetActive(true);
	}

	public void AudioMenu()
	{
		optionsMenu.SetActive(false);
		audioControlsMenu.SetActive(true);
	}

	public void SoundtrackMenu()
	{
		optionsMenu.SetActive(false);
		soundTracksMenu.SetActive(true);
	}

	public void AestheticMenu()
	{
		optionsMenu.SetActive(false);
		aestheticsMenu.SetActive(true);
	}

	public void BackFromOptionMenu()
	{
		optionsMenu.SetActive(false);
		canvas.SetActive(true);
	}

	public void BackFromAudioMenu()
	{
		audioControlsMenu.SetActive(false);
		optionsMenu.SetActive(true);
	}

	public void BackFromSoundtrackMenu()
	{
		soundTracksMenu.SetActive(false);
		optionsMenu.SetActive(true);
	}

	public void BackFromAestheticMenu()
	{
		aestheticsMenu.SetActive(false);
		optionsMenu.SetActive(true);
	}

	public void Exit(){
		Application.Quit ();
	}
		
}
