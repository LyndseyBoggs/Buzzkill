using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManagement : MonoBehaviour {

	public GameObject Scene1;
	public GameObject Scene2;
	public GameObject Scene3;
	public GameObject Scene4;
	public GameObject Scene5;
	public GameObject Scene6;

	//public int currentScene;

	// Use this for initialization
	void Start () {
		if (GameManager.instance.quest1Complete) {
			MoveToScene (6);
			if (GameManager.instance.quest2Complete) {
				MoveToScene (9);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToScene(int sceneNum){
		switch (sceneNum) {
		case 1: 
			Scene1.gameObject.SetActive (true);
			Scene2.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene4.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene5.gameObject.SetActive (false);
			Scene6.gameObject.SetActive (false);
			break;

		case 2:
			Scene2.gameObject.SetActive (true);
			Scene1.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene4.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene5.gameObject.SetActive (false);
			Scene6.gameObject.SetActive (false);
			break;

		case 3:
			Scene3.gameObject.SetActive (true);
			Scene1.gameObject.SetActive (false);
			Scene2.gameObject.SetActive (false);
			Scene4.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene5.gameObject.SetActive (false);
			Scene6.gameObject.SetActive (false);
			break;

		case 4:
			Scene4.gameObject.SetActive (true);
			Scene1.gameObject.SetActive (false);
			Scene2.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene5.gameObject.SetActive (false);
			Scene6.gameObject.SetActive (false);
			break;

		case 5:
			SceneManager.LoadScene ("Quest1");
			break;

		case 6: 
			Scene5.gameObject.SetActive (true);
			Scene1.gameObject.SetActive (false);
			Scene2.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene4.gameObject.SetActive (false);
			Scene6.gameObject.SetActive (false);
			break;

		case 7:
			Scene6.gameObject.SetActive (true);
			Scene1.gameObject.SetActive (false);
			Scene2.gameObject.SetActive (false);
			Scene3.gameObject.SetActive (false);
			Scene4.gameObject.SetActive (false);
			Scene5.gameObject.SetActive (false);
			break;

		case 8:
			SceneManager.LoadScene ("Quest2");
			break;
		}
	}
}
