using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints_Keffny : MonoBehaviour
{
	public int points = 100;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			GameManager.instance.score += points;
		}
		/*if(other.gameObject.name == "Baby(Clone)")
		{
			GameManager.instance.score += points;
		}

		if(other.gameObject.name == "Chunk(Clone)")
		{
			GameManager.instance.score += points;
		}

		if(other.gameObject.name == "Chunk1(Clone)")
		{
			GameManager.instance.score += points;
		}

		if(other.gameObject.name == "TeenBoy(Clone)")
		{
			GameManager.instance.score += points;
		}

		if(other.gameObject.name == "TeenGirl(Clone)")
		{
			GameManager.instance.score += points;
		}*/
	}
}