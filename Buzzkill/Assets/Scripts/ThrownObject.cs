using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ThrownObject : MonoBehaviour {
	
	Transform tf;
	public float speed = 25;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (!GameManager.instance.isGameOver) {
			tf.position += tf.right * Time.deltaTime * speed * GameManager.instance.worldSpeed;
		}*/

		if(GameObject.FindWithTag("Projectile").transform.position.x >= -30.4f)
		{
			Destroy(GameObject.FindWithTag("Projectile"));
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		BeeMovement player = other.GetComponent<BeeMovement> ();
		if (player) {
			player.Hit ();
			Destroy (gameObject);
		}
	}
}
