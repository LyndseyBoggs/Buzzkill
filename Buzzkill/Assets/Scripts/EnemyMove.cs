using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	Transform tf;
	public float speed;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		speed = Random.Range (5, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPaused) {
			return;
		}
		tf.position += tf.right * Time.deltaTime * speed;
	}

	void OnTriggerEnter2D(Collider2D other){
		BeeMovement player = other.GetComponent<BeeMovement> ();
		if (player) {
			player.Hit ();
			Destroy (gameObject);
		}
	}
}
