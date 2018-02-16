using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfScreen : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		BackGroundMove bg = other.GetComponent<BackGroundMove> ();
		if (!bg) {
			Destroy (other.gameObject);
		}
	}
}
