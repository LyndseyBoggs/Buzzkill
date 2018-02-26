using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgoStun_Keffny : MonoBehaviour
{
	public AudioClip stun;

	private AudioSource soundEffect;

	// Use this for initialization
	void Start ()
	{
		soundEffect = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "projectile_hotdog(Clone)")
		{
			soundEffect.PlayOneShot(stun);
		}
	}
}