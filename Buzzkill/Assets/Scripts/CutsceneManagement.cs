using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManagement : MonoBehaviour {

	public GameObject Scene1;
	public GameObject Scene2;
	//public int currentScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToScene(int sceneNum){
		switch (sceneNum) {
		case 1: 
			Scene1.gameObject.SetActive (true);
			Scene2.gameObject.SetActive (false);
			break;

		case 2:
			Scene2.gameObject.SetActive (true);
			Scene1.gameObject.SetActive (false);
			break;
		}
	}
}
