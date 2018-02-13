using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
	public int score;

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("Collision detected");
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}
}
