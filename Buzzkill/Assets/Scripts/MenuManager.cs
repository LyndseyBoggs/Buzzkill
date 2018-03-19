using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
	public AudioMixer masterControl;

	public GameObject pauseMenu;
	public GameObject pauseButton;

	public Slider masterVolume;
	public Slider musicVolume;
	public Slider effectsVolume;

	public float masterCurrentVolume;
	public float musicCurrentVolume;
	public float effectsCurrentVolume;
	string newMasterVolume = "MASTER_VOLUME_SLIDER";
	string newMusicVolume = "MUSIC_VOLUME_SLIDER";
	string newEffectsVolume = "EFFECTS_VOLUME_SLIDER";

	// Use this for initialization
	void Start ()
	{
		masterVolume.value = PlayerPrefs.GetFloat(newMasterVolume, 10);
		musicVolume.value = PlayerPrefs.GetFloat(newMusicVolume, 10);
		effectsVolume.value = PlayerPrefs.GetFloat(newEffectsVolume, 10);
		masterCurrentVolume = masterVolume.value;
		musicCurrentVolume = musicVolume.value;
		effectsCurrentVolume = effectsVolume.value;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
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

	public void OptionMenu()
	{
		SceneManager.LoadScene("Options");
	}

	public void AudioMenu()
	{
		SceneManager.LoadScene("Audio");
	}

	public void MasterVolumeControl(float volume1)
	{
		masterControl.SetFloat("masterVol", volume1);
		masterCurrentVolume = volume1;
		PlayerPrefs.SetFloat(newMasterVolume, volume1);
		PlayerPrefs.Save();
	}

	public void MusicVolumeControl(float volume2)
	{
		masterControl.SetFloat("musicVol", volume2);
		musicCurrentVolume = volume2;
		PlayerPrefs.SetFloat(newMusicVolume, volume2);
		PlayerPrefs.Save();
	}

	public void EffectsVolumeControl(float volume3)
	{
		masterControl.SetFloat("sfxVol", volume3);
		effectsCurrentVolume = volume3;
		PlayerPrefs.SetFloat(newEffectsVolume, volume3);
		PlayerPrefs.Save();
	}

	void OnEnable()
	{
		masterVolume.onValueChanged.AddListener(delegate{SliderCalled(masterVolume);});
		musicVolume.onValueChanged.AddListener(delegate{SliderCalled(musicVolume);});
		effectsVolume.onValueChanged.AddListener(delegate{SliderCalled(effectsVolume);});
	}

	void SliderCalled(Slider sliderMoved)
	{
		if(sliderMoved == masterVolume)
		{
			MasterVolumeControl(sliderMoved.value);
		}

		if(sliderMoved == musicVolume)
		{
			MusicVolumeControl(sliderMoved.value);
		}

		if(sliderMoved == effectsVolume)
		{
			EffectsVolumeControl(sliderMoved.value);
		}
	}

	public void SoundtrackMenu()
	{
		SceneManager.LoadScene("");
	}

	public void AestheticMenu()
	{
		SceneManager.LoadScene("Aesthetics");
	}

	public void BackFromOptionMenu()
	{
		SceneManager.LoadScene("StartScreen");
	}

	public void BackToOptionMenu()
	{
		SceneManager.LoadScene("Options");
	}
		
	public void Pause(){
		GameManager.instance.Pause ();
		pauseMenu.SetActive (!pauseMenu.activeSelf);
		pauseButton.SetActive (!pauseButton.activeSelf);
	}

	public void Exit(){
		Application.Quit ();
	}
		
}
