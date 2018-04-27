using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour {

	public GameObject cutScene;
	// Use this for initialization
	void Start () {
		GameManager.instance.gameScene = gameObject;
		GameManager.instance.cutScene = cutScene;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
