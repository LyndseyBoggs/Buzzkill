using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack_Melee : MonoBehaviour {

	public bool isAttacking;
	public float attackLength;
	public int scoreForKill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F)) {
			StartCoroutine (Attack ());
		}
	}

	void OnTriggerStay2D(Collider2D other){
		EnemyMove enemy = other.gameObject.GetComponent<EnemyMove> ();
		if (enemy && isAttacking) {
			if (!enemy.isDead) {
				enemy.isDead = true;
				GameManager.instance.score += scoreForKill;
				StopAllCoroutines ();
				isAttacking = false;
			}
		}
	}

	IEnumerator Attack(){
		isAttacking = true;
		float i = 0;
		while(i < attackLength){
			i += .1f;
			yield return new WaitForSeconds (.1f);
		}
		isAttacking = false;
	}
}
