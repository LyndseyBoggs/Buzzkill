using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDog_Keffny : MonoBehaviour
{
	public GameObject doge;
	public float spawnTime = 2f;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start ()
	{
		Invoke("SpawnDog", spawnTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void SpawnDog()
	{
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);
		Instantiate(doge, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}