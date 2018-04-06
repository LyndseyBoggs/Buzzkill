using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalkways : MonoBehaviour {

	public bool isForward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		ChasingEnemy atlas = other.GetComponent<ChasingEnemy> ();
		if (atlas) {
			if (isForward) {
				if (atlas.currentState == ChasingEnemy.States.idle) {
					atlas.currentState = ChasingEnemy.States.chasing;
				} else if (atlas.currentState == ChasingEnemy.States.chasing) {
					atlas.currentState = ChasingEnemy.States.killing;
				}
			} else {
				if (atlas.currentState == ChasingEnemy.States.chasing) {
					atlas.currentState = ChasingEnemy.States.idle;
				}
			}
		}
	}
}
