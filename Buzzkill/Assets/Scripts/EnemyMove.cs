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
	private AudioSource audSource;
	bool dead;
	public Sprite throwAnim;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		player = GameObject.FindObjectOfType<BeeMovement> ();
		coinValue = Random.Range (coinMin, coinMax);
		sRend = GetComponent<SpriteRenderer> ();
		audSource = GetComponent<AudioSource> ();
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
			tf.position -= tf.up;
			if (!dead) {
				Die ();
			}
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
		

	void ThrowObj()
	{
		float xDistance;
		xDistance = player.tf.position.x - tf.position.x;
		float yDistance;
		yDistance = player.tf.position.y - tf.position.y;
		float throwAngle;
		throwAngle = Mathf.Atan(yDistance + 4.905f) / xDistance;
		float totalVelocity = xDistance / Mathf.Cos(throwAngle);
		float xVelocity, yVelocity;
		xVelocity = totalVelocity * Mathf.Cos(throwAngle);
		yVelocity = totalVelocity * Mathf.Sin(throwAngle);
		GameObject bulletInstance = Instantiate(objToThrow, tf.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
		Rigidbody2D rigid;
		rigid = bulletInstance.GetComponent<Rigidbody2D>();
		rigid.velocity = new Vector2(xVelocity, yVelocity);
		//Instantiate (objToThrow, transform.position, transform.rotation);
		thrown = true;
		sRend.sprite = throwAnim;
	}

	void Die(){
		speed = 10;
		audSource.Play ();
		dead = true;
		//sRend.sprite = deadAnimation;
	}
}
