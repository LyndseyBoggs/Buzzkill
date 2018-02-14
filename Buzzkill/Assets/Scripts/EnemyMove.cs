using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	Transform tf;
	public	 float speed;
	public float throwRange;
	BeeMovement player;
	public GameObject objToThrow;
	private bool thrown;
	[HideInInspector]
	public bool isDead;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		player = GameObject.FindObjectOfType<BeeMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPaused) {
			return;
		}
		if (!isDead) {
			tf.position += tf.right * Time.deltaTime * speed * GameManager.instance.worldSpeed;
		} else {
			speed = 10;
			tf.position -= tf.up;
		}
		if (!thrown) {
			if ((player.transform.position.x - tf.position.x) < throwRange) {
				ThrowObj ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		
	}

	void ThrowObj(){
		Instantiate (objToThrow, transform.position, transform.rotation);
		thrown = true;
	}
}
