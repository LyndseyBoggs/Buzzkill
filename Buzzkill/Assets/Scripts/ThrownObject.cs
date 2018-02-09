using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownObject : MonoBehaviour {

	Transform tf;
	public float speed;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		tf.position += tf.right * Time.deltaTime * speed * GameManager.instance.worldSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		BeeMovement player = other.GetComponent<BeeMovement> ();
		if (player) {
			player.Hit ();
			Destroy (gameObject);
		}
	}
}
