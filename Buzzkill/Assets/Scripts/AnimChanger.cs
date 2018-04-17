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
	public bool waitForClick;
	public bool stopAtEnd;


	// Use this for initialization
	void Start () {
		sRend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitForClick) {

		} else {
		currentFrame++;
			if (currentFrame == framesToSwap) {
				currentAnim++;
				if (currentAnim >= anims.Length && !stopAtEnd) {
					currentAnim = 0;
				}
				sRend.sprite = anims [currentAnim];
				currentFrame = 0;
			}
		}
	}
}
