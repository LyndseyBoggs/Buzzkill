using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour {

	Transform tf;
	public float speed = 10;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		tf.position += tf.right * speed * Time.deltaTime * GameManager.instance.worldSpeed;
	}
}
