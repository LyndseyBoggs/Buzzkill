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
			PurchaseItemRequest request = new PurchaseItemRequest ();
			request.ItemId = "ExtraLife";
			request.Price = 100;
			request.VirtualCurrency = "GC";
			PlayFab.PlayFabClientAPI.PurchaseItem(request,PurchaseSuccess,OnPlayFabError);


		}

	}

	private void PurchaseSuccess(PurchaseItemResult result){
		Debug.Log ("Congrats you bought " + result.Items [0].DisplayName);
	}

	private void OnPlayFabError(PlayFabError error){
		Debug.LogError (error.GenerateErrorReport ());
	}

//	private void OnSubtractSuccess(ModifyUserVirtualCurrencyResult result){
//		Debug.Log ("Subtracted");
//	}
//	private void OnSubtractError(PlayFabError error){
//		Debug.LogError (error.GenerateErrorReport());
//	}
}
