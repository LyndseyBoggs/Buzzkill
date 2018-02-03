using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {
	[HideInInspector]
	public Transform tf;
	public float distance;
	public float playerSpeed = 5.0f;
	private int position = 0;
	private int maxPosition = 1;
	private int minPosition = -1;
	private bool isMoving;
	ChasingEnemy enemyChasing;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		enemyChasing = GameObject.FindObjectOfType<ChasingEnemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPaused) {
			return;
		}
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && position < maxPosition) {
			if (!isMoving) {
				StartCoroutine (MoveUp ());
				position++;
			}
		}
		if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && position > minPosition){
			if (!isMoving) {
				StartCoroutine (MoveDown ());
				position--;
			}
		}
	}

	IEnumerator MoveUp(){
		isMoving = true;
			for (int i = 0; i < distance;) {
				if (!GameManager.instance.isPaused) {
					tf.position += tf.up * Time.deltaTime * playerSpeed;
					i++;
				}
				yield return null;
			}
		isMoving = false;
	}
	IEnumerator MoveDown(){
		isMoving = true;
			for (int i = 0; i < distance;) {
				if (!GameManager.instance.isPaused) {
					tf.position -= tf.up * Time.deltaTime * playerSpeed;
					i++;
				}
				yield return null;
			}
		isMoving = false;
	}

	public void Hit(){
		if (enemyChasing.currentState == ChasingEnemy.States.idle) {
			enemyChasing.currentState = ChasingEnemy.States.chasing;
		} else if (enemyChasing.currentState == ChasingEnemy.States.chasing) {
			enemyChasing.currentState = ChasingEnemy.States.killing;
		}
	}

}
