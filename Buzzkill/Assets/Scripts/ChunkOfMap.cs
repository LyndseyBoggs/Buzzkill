using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkOfMap : MonoBehaviour {

	public Transform[] objs;
	public EnemySpawner owner;

	// Use this for initialization
	void Start () {
		owner = GameObject.FindObjectOfType<EnemySpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		objs = GetComponentsInChildren<Transform>();
		if (objs.Length == 1) {
			owner.spawnedObj = null;
			Destroy (gameObject);
		}
	}
}
