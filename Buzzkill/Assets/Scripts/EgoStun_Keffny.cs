using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgoStun_Keffny : MonoBehaviour
{
	public AudioClip stun;
	public static bool isstunned;
	BeeMovement thePlayer;
	SpriteRenderer sRend;
	public Sprite stunned;
	public Sprite pSprite;
	public float stunTime;

	private AudioSource soundEffect;

	// Use this for initialization
	void Start ()
	{
		thePlayer = GetComponent<BeeMovement>();
		sRend = GetComponent<SpriteRenderer>();
		soundEffect = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isstunned == true)
		{
			stunTime++;
		}

		if(stunTime >= 50f)
		{
			sRend.sprite = pSprite;
			stunTime = 0f;
			isstunned = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "projectile_hotdog(Clone)")
		{
			soundEffect.PlayOneShot(stun);
			isstunned = true;
			sRend.sprite = stunned;
		}
	}
}