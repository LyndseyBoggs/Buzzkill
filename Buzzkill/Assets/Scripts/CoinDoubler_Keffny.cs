using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDoubler_Keffny : MonoBehaviour
{

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
		BeeMovement player = other.GetComponent<BeeMovement>();
		BeeAttack_Melee Battack = other.GetComponent<BeeAttack_Melee>();

		if(player)
		{
			Battack.Dtimer = 10f;
			Battack.hasCoin = true;
			Destroy(gameObject);
		}
	}
}
