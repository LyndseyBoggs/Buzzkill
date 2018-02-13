using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints_Keffny : MonoBehaviour
{
	public GameManager gameManager;
	public int points = 100;

	// Use this for initialization
	void Awake ()
	{
		gameManager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Cube(Clone)")
		{
			gameManager.score += points;
		}
	}
}