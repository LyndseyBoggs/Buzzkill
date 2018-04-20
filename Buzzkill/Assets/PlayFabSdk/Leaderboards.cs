using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour {

	List<CharacterLeaderboardEntry> leaderBoard;
	public Text usernames;
	public Text distances;
	public Text times;
	public Text scores;

	// Use this for initialization
	void Start () {
		leaderBoard = new List<CharacterLeaderboardEntry> ();
		GenerateLeaderBoard ("High Score");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha8)) {
			GenerateLeaderBoard ("High Score");
		}
	}

	public void GenerateLeaderBoard(string statToGenerate){
		GetLeaderboardRequest request = new GetLeaderboardRequest ();
		request.StartPosition = 0;
		request.StatisticName = statToGenerate;
		//request.MaxResultsCount = 2;
		PlayFabClientAPI.GetLeaderboard (request, LeaderBoardGenerated, OnPlayFabError);
	}

	private void LeaderBoardGenerated(GetLeaderboardResult result){
		Debug.Log ("LEADERBOARDS");
		usernames.text = "";
		scores.text = "";
		for (int i = 0; i < result.Leaderboard.Count; i++) {
			//Debug.Log (result.Leaderboard [i].Position);
			//Debug.Log (result.Leaderboard [i].DisplayName);
			//Debug.Log (result.Leaderboard [i].StatValue);
			//Debug.Log("List");
			usernames.text = usernames.text + result.Leaderboard[i].DisplayName;
			usernames.text = usernames.text + "\n";
			scores.text = scores.text + result.Leaderboard [i].StatValue;
			scores.text = scores.text + "\n";
		}
	}

	private void OnPlayFabError(PlayFabError error){
		Debug.LogError (error.GenerateErrorReport());
	}
}
