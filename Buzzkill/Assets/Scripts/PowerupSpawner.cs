using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {

	[Tooltip("Bigger the number, Lower the spawn")]
	public int spawnChance = 1000;
	public GameObject[] objsToSpawn;
	public GameObject objToSpawn;
	Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();	
	}
	
	// Update is called once per frame
	void Update () {
		int randoNum = Random.Range (0, spawnChance);
		if (randoNum == 0) {
			randoNum = Random.Range (0, objsToSpawn.Length);
			objToSpawn = objsToSpawn [randoNum].gameObject;
			Instantiate (objToSpawn, tf.position, tf.rotation);
		}
	}
}
