using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabStats : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SavePlayerStats(){
		AddUserVirtualCurrencyRequest money = new AddUserVirtualCurrencyRequest ();
		money.Amount = GameManager.instance.coins;
		money.VirtualCurrency = "GC";
		PlayFabClientAPI.AddUserVirtualCurrency(money, MoneyAdding ,OnPlayFabError);
		UpdateUserDataRequest request = new UpdateUserDataRequest ();
		request.Data = new Dictionary<string, string> ();
		request.Data.Add ("LastScore", GameManager.instance.score.ToString ());
		PlayFabClientAPI.UpdateUserData (request, PlayerDataSaved, OnPlayFabError);
		Dictionary<string,int> stats = new Dictionary<string,int> ();
		stats.Add ("LastScore", GameManager.instance.score);
		storeStats (stats);
	}

	private void PlayerDataSaved(UpdateUserDataResult result){
		Debug.Log ("Data Saved");
	}

	private void MoneyAdding(ModifyUserVirtualCurrencyResult result){
		Debug.Log ("You earned " + result.BalanceChange + ". Your total is now " + result.Balance + ".");
	}

	private void OnPlayFabError(PlayFabError error){
		Debug.LogError (error);
	}

	private void storeStats(Dictionary<string, int> stats){
		UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest();
		PlayFab.ClientModels.StatisticUpdate stat = new PlayFab.ClientModels.StatisticUpdate ();
		//Dictionary<string, int> dict = new Dictionary<string, int> ();
		//dict.Add("Score", GameManager.instance.score);
		stat.StatisticName = "LastScore";
		stat.Value = GameManager.instance.score;
		CheckHighscore ();
		List<StatisticUpdate> statList = new List<StatisticUpdate>();
		statList.Add(stat);
		request.Statistics = statList;
		PlayFabClientAPI.UpdatePlayerStatistics (request, UpdatePlayerStats, OnPlayFabError);

	}

		private void UpdatePlayerStats(UpdatePlayerStatisticsResult result){
		Debug.Log ("Stat Saved");
	}
					
	private void ListCharacters(ListUsersCharactersResult result){
		Debug.Log (result);
	}

	private void CheckHighscore(){
		GetPlayerStatisticsRequest request = new GetPlayerStatisticsRequest ();
		List<string> highScore = new List<string> ();
		highScore.Add ("High Score");
		request.StatisticNames = highScore;
		PlayFabClientAPI.GetPlayerStatistics (request, GetStatsResult, OnPlayFabError);
	}

	private void GetStatsResult(GetPlayerStatisticsResult result){
		if (result.Statistics.Count > 0) {
			Debug.Log (result.Statistics [0].StatisticName);
			if (result.Statistics [0].Value < GameManager.instance.score) {
				UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest ();
				PlayFab.ClientModels.StatisticUpdate stat = new PlayFab.ClientModels.StatisticUpdate ();
				stat.StatisticName = "High Score";
				stat.Value = GameManager.instance.score;
				List<StatisticUpdate> statList = new List<StatisticUpdate> ();
				statList.Add (stat);
				request.Statistics = statList;
				PlayFabClientAPI.UpdatePlayerStatistics (request, UpdatePlayerStats, OnPlayFabError);
			}
		} else {
			UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest ();
			PlayFab.ClientModels.StatisticUpdate stat = new PlayFab.ClientModels.StatisticUpdate ();
			stat.StatisticName = "High Score";
			stat.Value = GameManager.instance.score;
			List<StatisticUpdate> statList = new List<StatisticUpdate> ();
			statList.Add (stat);
			request.Statistics = statList;
			PlayFabClientAPI.UpdatePlayerStatistics (request, UpdatePlayerStats, OnPlayFabError);
			Debug.Log ("High Score Updated");
		}
	}
}
