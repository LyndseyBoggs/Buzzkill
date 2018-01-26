using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public float maxSpeed = -5;
	public Vector3 userDirection = Vector3.left;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (userDirection * maxSpeed * Time.deltaTime);
		
	}
}
