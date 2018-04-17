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
	SceneTransition nextScene;


	// Use this for initialization
	void Start () {
		sRend = GetComponent<SpriteRenderer> ();
		nextScene = GetComponent<SceneTransition> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitForClick) {
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				currentAnim++;
				if (currentAnim >= anims.Length) {
					nextScene.NextScene ();
				} else {
					sRend.sprite = anims [currentAnim];
				}

			}
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
