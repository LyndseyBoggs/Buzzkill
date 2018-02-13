using UnityEngine;
using System.Collections;

public class Shank : MonoBehaviour {

	//Allows changing of bullet speed, delay and offset from spawn
	public Vector3 stingerOffset = new Vector3(0, 0.5f, 0);

	public GameObject Stinger;
	public float shankDelay = 0.25f;
	float cooldownTimer = 0;

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if( Input.GetKeyDown(KeyCode.F) && cooldownTimer <= 0 ) {
			// Shoots bullet on command
			cooldownTimer = shankDelay;

			Vector3 offset = transform.rotation * stingerOffset;

			GameObject StingerGO = (GameObject)Instantiate(Stinger, transform.position + offset, transform.rotation);
		}
	}
}
