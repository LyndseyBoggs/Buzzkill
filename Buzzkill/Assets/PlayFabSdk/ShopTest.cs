using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ShopTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.L)) {
			SubtractUserVirtualCurrencyRequest request = new SubtractUserVirtualCurrencyRequest ();
			request.Amount = 10;
			request.VirtualCurrency = "GC";
			PlayFab.PlayFabClientAPI.SubtractUserVirtualCurrency(request,OnSubtractSuccess,OnSubtractError);
			UserAccountInfo info = new UserAccountInfo ();
		}
	}

	private void OnSubtractSuccess(ModifyUserVirtualCurrencyResult result){
		Debug.Log ("Subtracted");
	}
	private void OnSubtractError(PlayFabError error){
		Debug.LogError (error.GenerateErrorReport());
	}
}
