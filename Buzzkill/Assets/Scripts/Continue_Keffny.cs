using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue_Keffny : MonoBehaviour
{
	public Button button1;
	public Button button2;

	// Use this for initialization
	void Start ()
	{
		Button btn1 = button1.GetComponent<Button>();
		Button btn2 = button2.GetComponent<Button>();
		btn1.onClick.AddListener(Yes);
		btn2.onClick.AddListener(No);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void Yes()
	{
		if (GameManager.instance.pLives > 0)
		{

			if (GameManager.instance.pLives > 0)
			{
				GameManager.instance.doge = GameObject.FindObjectOfType<ChasingEnemy> ();
				GameManager.instance.pLives -= 1;
				SceneManager.LoadScene ("FredTest");
				GameManager.instance.isGameOver = false;
				//score = 0;
				GameManager.instance.worldSpeed -= 3;
				GameManager.instance.doge.currentState = ChasingEnemy.States.idle;
				if (GameManager.instance.worldSpeed < 1)
				{
					GameManager.instance.worldSpeed = 1;
				}
				GameManager.instance.isPaused = false;
			}
			if (GameManager.instance.pLives == 0 && GameManager.instance.isGameOver == true)
			{
				GameManager.instance.GameOver ();
			}
		}
		if (GameManager.instance.pLives == 0 && GameManager.instance.isGameOver == true)
		{
			GameManager.instance.GameOver ();
		}
	}

	void No()
	{
		GameManager.instance.GameOver();
	}
}