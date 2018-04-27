using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.instance.cutScene = gameObject;
		Debug.LogError ("Pls");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
