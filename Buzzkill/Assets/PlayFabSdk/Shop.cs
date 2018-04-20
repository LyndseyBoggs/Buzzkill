using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Shop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PurchaseDouble(){
		PurchaseItemRequest request = new PurchaseItemRequest ();
		request.ItemId = "DoubleCoins";
		request.Price = 99;
		request.VirtualCurrency = "GC";
		PlayFabClientAPI.PurchaseItem(request, PurchaseSuccess, OnPlayFabError);
	}

	public void PurchaseLife(){
		PurchaseItemRequest request = new PurchaseItemRequest ();
		request.ItemId = "ExtraLife";
		request.Price = 99;
		request.VirtualCurrency = "GC";
		PlayFabClientAPI.PurchaseItem (request, PurchaseSuccess, OnPlayFabError);
	}

	public void PurchaseShield(){
		PurchaseItemRequest request = new PurchaseItemRequest ();
		request.ItemId = "Shield";
		request.Price = 99;
		request.VirtualCurrency = "GC";
		PlayFabClientAPI.PurchaseItem (request, PurchaseSuccess, OnPlayFabError);
	}

	private void PurchaseSuccess(PurchaseItemResult result){
				Debug.Log ("You purchased " + result.Items[0].DisplayName + ". You have " + result.Items [0].RemainingUses + ".");
	}
				
	private void OnPlayFabError(PlayFabError error){
		Debug.Log (error.GenerateErrorReport ());
	}
}
