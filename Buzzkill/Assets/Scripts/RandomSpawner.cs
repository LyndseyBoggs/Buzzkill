using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {
	[SerializeField]
	private GameObject[] objsPossible;
	private GameObject objToSpawn;
	private GameObject spawnedObj;
	[Tooltip ("Higher the number, lower the spawn chance"), SerializeField]
	private int spawnChance;
	Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPaused) {
			return;
		}
		int randoNum = Random.Range (0, spawnChance);
		if (randoNum == 0) {
			spawnChance = 500 / (int) GameManager.instance.worldSpeed;
			randoNum = Random.Range (0, objsPossible.Length);
			objToSpawn = objsPossible [randoNum].gameObject;
			spawnedObj = Instantiate (objToSpawn, tf.position, tf.rotation);
		} else {
			spawnChance--;	
		}
	}
}
