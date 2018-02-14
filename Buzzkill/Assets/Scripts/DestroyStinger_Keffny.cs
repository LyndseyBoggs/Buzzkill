using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStinger_Keffny : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Destroy(gameObject, 2);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		EnemyMove enemy = other.GetComponent<EnemyMove> ();
		if (enemy) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
