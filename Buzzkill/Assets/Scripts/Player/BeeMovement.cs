﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {
	[HideInInspector]
	public Transform tf;
	private Vector3 startPos;
	public float distance;
	public float playerSpeed = 5.0f;
	public int position = 1;
	private int maxPosition = 2;
	private int minPosition = 0;
	public bool isMoving;
	ChasingEnemy enemyChasing;
	public Transform[] positions;
	public Transform goal;
	public float proximity;
	//[HideInInspector]
	public bool hasShield;
	public SpriteRenderer sRend;
	public GameObject shieldSprite;
	public AudioClip deathSound;
	private AudioSource audSource;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		enemyChasing = GameObject.FindObjectOfType<ChasingEnemy> ();
		sRend = GetComponent<SpriteRenderer> ();
		startPos = tf.position;
		audSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tf.position.y > 35 || tf.position.y < -35) {
			tf.position = startPos;
		}
		if (GameManager.instance.isPaused || GameManager.instance.isGameOver) {
			return;
		}
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && position > minPosition) {
			if (!isMoving) {
				StartCoroutine (MoveUp ());
			}
		}
		if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && position < maxPosition){
			if (!isMoving) {
				StartCoroutine (MoveDown ());
			}
		}
	}

	IEnumerator MoveUp(){
		isMoving = true;
		goal = positions [position - 1];
		Vector3 vecToGoal = goal.position - tf.position;
		while(vecToGoal.magnitude > proximity){
			vecToGoal = goal.position - tf.position;
			if (!GameManager.instance.isPaused) {
				tf.position += tf.up * Time.deltaTime * playerSpeed;
			}
			yield return null;
			}
		isMoving = false;
		position--;
	}
	IEnumerator MoveDown(){
		isMoving = true;
		goal = positions [position + 1];
		Vector3 vecToGoal = goal.position - tf.position;
		while(vecToGoal.magnitude > proximity){
			vecToGoal = goal.position - tf.position;
			if (!GameManager.instance.isPaused) {
				tf.position -= tf.up * Time.deltaTime * playerSpeed;
			}
				yield return null;
			}
		isMoving = false;
		position++;
	}

	public void Hit(){
		audSource.Play ();
		if (!hasShield) {
			if (enemyChasing.currentState == ChasingEnemy.States.idle) {
				enemyChasing.currentState = ChasingEnemy.States.chasing;
				enemyChasing.clipPlaying = false;
			} else if (enemyChasing.currentState == ChasingEnemy.States.chasing) {
				enemyChasing.currentState = ChasingEnemy.States.killing;
				audSource.clip = deathSound;
				audSource.Play ();
			}
		} else {
			hasShield = false;
			shieldSprite.SetActive (false);
		}
	}
}
