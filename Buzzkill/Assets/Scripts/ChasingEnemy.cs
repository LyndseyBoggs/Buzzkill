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
	private AudioSource audSource;
	public AudioClip seldomBark;
	public AudioClip oftenBark;
	public bool clipPlaying;

	SpriteRenderer sRend;
	public Sprite eating;
	public float gameOver;
	public float deathTimer = 2f;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		sRend = GetComponent<SpriteRenderer>();
		audSource = GetComponent<AudioSource> ();
		//player = GameObject.FindObjectOfType<BeeMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vecToGoal = (player.tf.position + offset) - tf.position;
		Vector3.Normalize (vecToGoal);
		if (currentState == States.idle) {
			offset = idleOffset;
			isChasing = false;
			audSource.clip = seldomBark;
			if (!clipPlaying) {
				audSource.Play ();
				clipPlaying = true;
			}
		} else if (currentState == States.chasing) {
			offset = chasingOffset;
			if (!isChasing) {
				StartCoroutine (ChasingTimer ());
				isChasing = true;
				audSource.clip = oftenBark;
				if (!clipPlaying) {
					audSource.Play ();
					clipPlaying = true;
				}
			}
		} else if (currentState == States.killing) {
			gameOver += Time.deltaTime;
			offset = new Vector3 (0, 0, 0);
			//sRend.sprite = eating;
			StopAllCoroutines ();
			GameManager.instance.worldSpeed = 0;
			GameManager.instance.isGameOver = true;
			if(gameOver >= deathTimer)
			{
				GameManager.instance.GameOver ();
			}
			//GameManager.instance.GameOver ();
		}
		tf.position += vecToGoal * Time.deltaTime * speed; //* GameManager.instance.worldSpeed;

	}

	IEnumerator ChasingTimer(){
		float timer = 0;
		while (timer < chaseTime) {
			timer += .5f;
			yield return new WaitForSeconds (.5f);
		}
		currentState = States.idle;
		clipPlaying = false;
	}
}
