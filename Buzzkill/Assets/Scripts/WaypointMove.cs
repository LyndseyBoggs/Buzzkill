using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour {

	public Transform[] waypoints;
	public enum MoveState {stopAtEnd, pingPong, loop, random} 
	public MoveState moveState;
	public bool isMovingForward;
	public bool isMoving;
	private Transform tf;
	public int currentWaypoint;
	public float turnSpeed;
	public float moveSpeed;
	public float proximity;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (isMoving) {
			currentWaypoint = (int)Mathf.Clamp (currentWaypoint, 0, waypoints.Length -1);
			Vector3 newDirection = waypoints [currentWaypoint].position - tf.position;
			Quaternion goalRotation = Quaternion.LookRotation (newDirection);
			tf.rotation = Quaternion.RotateTowards (tf.rotation, goalRotation, turnSpeed);
			tf.position += tf.forward * moveSpeed * Time.deltaTime;
			float distanceToWaypoint = Vector3.Distance (tf.position, waypoints [currentWaypoint].position);
			if (distanceToWaypoint <= proximity) {
				if (moveState == MoveState.random) {
					currentWaypoint = Random.Range (0, waypoints.Length);
				} else {
					if (isMovingForward) {
						currentWaypoint++;
						if (currentWaypoint > waypoints.Length - 1) {
							switch (moveState) {
							case MoveState.loop:
								currentWaypoint = 0;
								break;

							case MoveState.pingPong:
								isMovingForward = false;
								break;

							case MoveState.stopAtEnd:
								isMoving = false;
								break;
							}
						}
					} else {
						currentWaypoint--;
						if (currentWaypoint < 0) {
							switch (moveState) {
							case MoveState.loop:
								currentWaypoint = waypoints.Length - 1;
								break;

							case MoveState.pingPong:
								isMovingForward = true;
								break;

							case MoveState.stopAtEnd:
								isMoving = false;
								break;
							}
						}
					}
				}
			}
		}
	}
}