using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}

}