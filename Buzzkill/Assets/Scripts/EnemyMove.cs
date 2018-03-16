using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	SpriteRenderer sRend;
	Transform tf;
	public Sprite aimAnimation;
	public float aggroRange;
	public float speed;
	public float throwRange;
	BeeMovement player;
	public GameObject objToThrow;
	private bool thrown;
	[HideInInspector]
	public bool isDead;
	public int coinMin = 1;
	public int coinMax = 5;
	public int coinValue;
	public Sprite deadAnimation;
	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		player = GameObject.FindObjectOfType<BeeMovement> ();
		coinValue = Random.Range (coinMin, coinMax);
		sRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPaused) {
			return;
		}
		if (!isDead) {
			tf.position += tf.right * Time.deltaTime * speed * GameManager.instance.worldSpeed;
		} else {
			//sRend.sprite = deadAnimation;
			speed = 10;
			tf.position -= tf.up;
		}
		if (!thrown) {
			if ((player.transform.position.x - tf.position.x) < aggroRange) {
			//	sRend.sprite = aimAnimation;
			}
			if ((player.transform.position.x - tf.position.x) < throwRange) {
				ThrowObj ();
			}
		}
	}
		

	void ThrowObj(){
		Instantiate (objToThrow, transform.position, transform.rotation);
		thrown = true;
	}
}
