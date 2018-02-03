using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour {

	Transform tf;
	public BeeMovement player;
	private Vector3 offset;
	public Vector3 idleOffset;
	public Vector3 chasingOffset;
	public enum States{idle, chasing, killing}
	public States currentState;
	public float speed;
	bool isChasing;
	public float chaseTime;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		//player = GameObject.FindObjectOfType<BeeMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vecToGoal = (player.tf.position + offset) - tf.position;
		if (currentState == States.idle) {
			offset = idleOffset;
			isChasing = false;
		} else if (currentState == States.chasing) {
			offset = chasingOffset;
			if (!isChasing) {
				StartCoroutine (ChasingTimer ());
				isChasing = true;
			}
		} else if (currentState == States.killing) {
			offset = new Vector3 (0, 0, 0);
			StopAllCoroutines ();
		}
		tf.position += vecToGoal * Time.deltaTime * speed;

	}

	IEnumerator ChasingTimer(){
		float timer = 0;
		while (timer < chaseTime) {
			timer += .5f;
			yield return new WaitForSeconds (.5f);
		}
		currentState = States.idle;
	}
}
