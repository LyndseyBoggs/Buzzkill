using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour {

	public GameObject[] objsToSpawn;
	private Transform tf;
	public bool waiting;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!waiting) {
			StartCoroutine (SpawnBackground ());
		}
	}

	IEnumerator SpawnBackground(){
		waiting = true;
		int rando = Random.Range (0, objsToSpawn.Length);
		GameObject spawned = Instantiate (objsToSpawn [rando], tf.position, tf.rotation);
		Destroy (spawned, 20);
		yield return new WaitForSeconds (10f);
		waiting = false;
	}
}
