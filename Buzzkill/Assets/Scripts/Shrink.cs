using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour {

	Transform obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (obj) {
			obj.localScale -= new Vector3 (.00008f, .00008f , 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		obj = other.GetComponent<Transform> ();
	}
}
