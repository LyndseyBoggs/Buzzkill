using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChanger : MonoBehaviour {

	bool swapFrame;
	public int framesToSwap;
	int currentFrame;
	int currentAnim;
	SpriteRenderer sRend;
	public Sprite[] anims;


	// Use this for initialization
	void Start () {
		sRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentFrame++;
		if (currentFrame == framesToSwap) {
			currentAnim++;
			if (currentAnim >= anims.Length) {
				currentAnim = 0;
			}
			sRend.sprite = anims [currentAnim];
			currentFrame = 0;
		}
	}
}
