using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfScreen : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		ChasingEnemy allowed = other.GetComponent<ChasingEnemy> ();
		if (!allowed) {
			Destroy (other.gameObject);
		}
	}
}
