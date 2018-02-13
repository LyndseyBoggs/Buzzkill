using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Keffny : MonoBehaviour
{
	public float gameTimer = 60f;
	public Text text;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameTimer -= Time.deltaTime;
		text.text = "Timer: " + Mathf.Round(gameTimer);
	}
}