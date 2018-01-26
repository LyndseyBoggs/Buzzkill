using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {

	public float playerSpeed = 5.0f;
	public float maxPosition = 3;
	public float minPosition = -3;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, 0, 0);


	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.UpArrow) && transform.position.y < maxPosition) {
			Vector3.Lerp (transform.position, transform.position += new Vector3 (0, 3, 0), Time.deltaTime * playerSpeed);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && transform.position.y > minPosition){
			transform.position += new Vector3 (0, -3, 0);
		}
	}
}
