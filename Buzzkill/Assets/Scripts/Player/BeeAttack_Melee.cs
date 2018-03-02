using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack_Melee : MonoBehaviour {

	public bool isAttacking;
	public float attackLength;
	public int scoreForKill;
	public static int killedEnemies;

	public float Dtimer;
	public bool hasCoin = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine (Attack ());
		}

		if (Dtimer > 0f)
		{
			Dtimer -= Time.deltaTime;
			if(Dtimer <= 0f)
			{
				hasCoin = false;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		EnemyMove enemy = other.gameObject.GetComponent<EnemyMove> ();
		if (enemy && isAttacking && !enemy.isDead) {
			if (hasCoin == true)
			{
				enemy.isDead = true;
				GameManager.instance.score += scoreForKill;
				GameManager.instance.coins += enemy.coinValue * 2;
				GameManager.instance.totalCoins += enemy.coinValue * 2;
				StopAllCoroutines();
				isAttacking = false;
				killedEnemies++;
			}
			else{
				enemy.isDead = true;
				GameManager.instance.score += scoreForKill;
				GameManager.instance.coins += enemy.coinValue;
				GameManager.instance.totalCoins += enemy.coinValue;
				StopAllCoroutines ();
				isAttacking = false;
				killedEnemies++;
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
