using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public enum PowerupList {shield, powerup1, powerup2}
	public PowerupList powerup;
	Transform tf;
	public float speed;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPaused) {
			return;
		}
		tf.position += tf.right * Time.deltaTime * speed * GameManager.instance.worldSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		BeeMovement player = other.GetComponent<BeeMovement> ();
		if (player) {
			player.hasShield = true;
			player.sRend.color = Color.green;
			Destroy (gameObject);
		}
	}
}
