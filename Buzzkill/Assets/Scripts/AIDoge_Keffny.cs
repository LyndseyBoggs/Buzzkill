using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDoge_Keffny : MonoBehaviour
{
	public Transform player;
	//Speed of chasing dog
	public float speed = .5f;

	// Use this for initialization
	void Start ()
	{
		//Finds and grabs the player gameobject
		player = GameObject.Find("Bee").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (player.transform.position == new Vector3(0, 3, 0))
		{
			transform.position = new Vector3(3, 3, 0);
		}
		else if (player.transform.position == new Vector3(0, 0,0))
		{
			transform.position = new Vector3(3, 0, 0);
		}
		else if (player.transform.position == new Vector3(0, -3,0))
		{
			transform.position = new Vector3(3, -3, 0);
		}*/
		//Moves the dog to the players position
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}
}