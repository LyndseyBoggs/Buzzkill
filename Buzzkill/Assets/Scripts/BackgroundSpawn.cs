using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour {

	public GameObject[] objsToSpawn;
	public Transform spawnLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		int rando = Random.Range (0, objsToSpawn.Length);
		Instantiate (objsToSpawn [rando].gameObject, spawnLocation.position, spawnLocation.rotation);
		Destroy (other.gameObject);
	}


}
