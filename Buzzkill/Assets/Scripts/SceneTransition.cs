using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

	public int goToScene;
	public CutsceneManagement cut;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		cut.MoveToScene (goToScene);
	}

	public void NextScene(){
		cut.MoveToScene (goToScene);
	}
}
