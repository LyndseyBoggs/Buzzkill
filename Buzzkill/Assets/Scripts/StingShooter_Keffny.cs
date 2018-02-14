using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingShooter_Keffny : MonoBehaviour
{
	public Rigidbody2D stingerShot;
	public Transform stingerShoot;
	public float coolDown = 10f;
	float timer;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= coolDown && Input.GetKeyDown(KeyCode.Space))
		{
			Sting();
		}
	}

	void Sting()
	{
		timer = 0f;
		//Instantiate(stingerShot, stingerShoot.position, stingerShoot.rotation);
		Rigidbody2D beeStinger = Instantiate(stingerShot, stingerShoot.position, stingerShoot.rotation) as Rigidbody2D;
		Debug.Log ("GSFASF");
	}
}