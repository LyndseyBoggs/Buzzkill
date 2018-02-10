using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingShooter_Keffny : MonoBehaviour
{
	public Rigidbody2D stingerShot;
	public Transform stingerShoot;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Sting();
		}
	}

	void Sting()
	{
		//Instantiate(stingerShot, stingerShoot.position, stingerShoot.rotation);
		Rigidbody2D beeStinger = Instantiate(stingerShot, stingerShoot.position, stingerShoot.rotation) as Rigidbody2D;
	}
}