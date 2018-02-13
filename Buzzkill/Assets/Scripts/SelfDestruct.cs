using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	//Makes bullets dissapear after awhile
	public float timer = .1f;

	void Update () {
		timer -= Time.deltaTime;

		if(timer <= 0) {
			Destroy(gameObject);
		}
	}
}

