using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int startingHealth = 1; //Enemy Starting health
	public int currentHealth;
	public float sinkSpeed = 2.5f;


	//references animator and capsule collider and whether the enemy is dead and whether
	//the enemy is sinking
	Animator anim;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;


	void Awake ()
	{
		// Reference setup
		anim = GetComponent <Animator> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();

		//sets health when enemy spawns
		currentHealth = startingHealth;
	}

	void Update ()
	{
		//if the enemy should sink
		if(isSinking)
		{
			// sink the enemy down
			transform.Translate (-Vector3 * sinkSpeed * Time.deltaTime)
		}
	}


	public void TakeDamage (int amount, Vector3 hitpoint)
	{
		//if enemy is dead
		if (isDead) {
			//dont run damage
			return;
		}
		currentHealth -= amount

		//if current health is less than or equal to zero
		if (currentHealth <= 0)
		{
			// enemy is dead
			Death ();
		}
	}

	void Death ()
	{
		//the enemy is dead
		isDead = true;

		//makes shots pass through
		capsuleCollider.isTrigger = true;

		//tells animator enemy is dead
		anim.SetTrigger("Dead");
	}

	public void StartSinking ()
	{
		//find and diable navmesh
		GetComponent <NavMeshAgent> ().enabled = false;

		//find and make the rigidbody component and make it kinematic
		GetComponent <Rigidbody> ().isKinematic = true;

		//enemy should now sink
		isSinking = true;

		//after 2 seconds destroy enemy
		Destroy (gameObject, 2f)
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
