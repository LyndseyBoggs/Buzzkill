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

	public GameObject continueScreen;


	public GameObject StartScreenCanvas;
	public GameObject StartStartCanvas;

	//public Slider masterVolume;
	public Slider musicVolume;
	public Slider effectsVolume;

	//public float masterCurrentVolume;
	public float musicCurrentVolume;
	public float effectsCurrentVolume;
	//string newMasterVolume = "MASTER_VOLUME_SLIDER";
	string newMusicVolume = "MUSIC_VOLUME_SLIDER";
	string newEffectsVolume = "EFFECTS_VOLUME_SLIDER";


	public AudioSource audio;
	public AudioSource shopAudio;
	public AudioClip soundtrack1;
	public AudioClip soundtrack2;
	public AudioClip soundtrack3;
	public AudioClip soundtrack4;

	// Use this for initialization
	void Start ()
	{
		//masterVolume.value = PlayerPrefs.GetFloat(newMasterVolume, 0);
		musicVolume.value = PlayerPrefs.GetFloat(newMusicVolume, 0);
		effectsVolume.value = PlayerPrefs.GetFloat(newEffectsVolume, 0);
		//masterCurrentVolume = masterVolume.value;
		musicCurrentVolume = musicVolume.value;
		effectsCurrentVolume = effectsVolume.value;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(audio.isPlaying)
		{
			Destroy(GameObject.FindGameObjectWithTag("MainAudio"));
		}
	}

	public void StartGame(){
		if(Application.loadedLevelName == "StartScreen")
		{
			audio.Play();
		}
		SceneManager.LoadScene ("FredTest");
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

	public void MainMenu()
	{
		Destroy(GameObject.Find("MenuManager"));
		GameManager.instance.isGameOver = false;
		SceneManager.LoadScene ("StartScreen");
	}

	/*public void MasterVolumeControl(float volume1)
	{
		masterControl.SetFloat("masterVol", volume1);
		masterCurrentVolume = volume1;
		PlayerPrefs.SetFloat(newMasterVolume, volume1);
		PlayerPrefs.Save();
	}*/

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
		//masterVolume.onValueChanged.AddListener(delegate{SliderCalled(masterVolume);});
		musicVolume.onValueChanged.AddListener(delegate{SliderCalled(musicVolume);});
		effectsVolume.onValueChanged.AddListener(delegate{SliderCalled(effectsVolume);});
	}

	void SliderCalled(Slider sliderMoved)
	{
		/*if(sliderMoved == masterVolume)
		{
			MasterVolumeControl(sliderMoved.value);
		}*/

		if(sliderMoved == musicVolume)
		{
			MusicVolumeControl(sliderMoved.value);
		}

		if(sliderMoved == effectsVolume)
		{
			EffectsVolumeControl(sliderMoved.value);
		}
	}

	public void Soundtrack1()
	{
		audio.clip = soundtrack1;
		audio.Stop();
		audio.Play();
		DontDestroyOnLoad(audio.gameObject);
	}

	public void Soundtrack2()
	{
		audio.clip = soundtrack2;
		audio.Stop();
		audio.Play();
		DontDestroyOnLoad(audio.gameObject);
	}

	public void Soundtrack3()
	{
		audio.clip = soundtrack3;
		audio.Stop();
		audio.Play();
		DontDestroyOnLoad(audio.gameObject);
	}

	public void Soundtrack4()
	{
		audio.clip = soundtrack4;
		audio.Stop();
		audio.Play();
		DontDestroyOnLoad(audio.gameObject);
	}

	public void ShopSoundtrack1()
	{
		shopAudio.clip = soundtrack1;
		shopAudio.Stop();
		shopAudio.Play();
	}

	public void ShopSoundtrack2()
	{
		shopAudio.clip = soundtrack2;
		shopAudio.Stop();
		shopAudio.Play();
	}

	public void ShopSoundtrack3()
	{
		shopAudio.clip = soundtrack3;
		shopAudio.Stop();
		shopAudio.Play();
	}
		
	public void Pause(){
		GameManager.instance.Pause ();
		pauseMenu.SetActive (!pauseMenu.activeSelf);
		pauseButton.SetActive (!pauseButton.activeSelf);
	}

	public void ContinueScreen()
	{
		GameManager.instance.Pause();
		continueScreen.SetActive(!continueScreen.activeSelf);
	}

	/*public void ContinueYes(){
		GameManager.instance.ContinueYes ();
	}

	public void ContinueNo(){
		GameManager.instance.ContinueNo ();
	}*/

	public void Exit(){
		Application.Quit ();
	}
}