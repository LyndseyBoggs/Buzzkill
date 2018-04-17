using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginWithPlayfab : MonoBehaviour {

	public InputField usernameBox;
	public InputField passwordBox;
	public InputField emailBox;
	private string titleid = "B613";
	private string password;
	private string username;
//	private bool newlyCreated;
//	System.Action<LoginResult> OnLoginResult;
//	System.Action<PlayFabError> OnPlayFabError;
//	System.Action<RegisterPlayFabUserResult> OnRegisterResult;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TryLogin(){
		LoginWithPlayFabRequest request = new LoginWithPlayFabRequest ();
		request.Username = usernameBox.text;
		request.Password = passwordBox.text;
		request.TitleId = titleid;
		PlayFabClientAPI.LoginWithPlayFab (request, OnLoginResult, OnPlayFabError);
	}

	public void CreateAccount(){
		RegisterPlayFabUserRequest create = new RegisterPlayFabUserRequest ();
		create.Username = usernameBox.text;
		create.Email = emailBox.text;
		create.Password = passwordBox.text;
		create.TitleId = titleid;
		PlayFabClientAPI.RegisterPlayFabUser (create, OnRegisterResult, OnPlayFabError);
	}
	private void OnLoginResult(LoginResult result){
		Debug.Log ("You succesfully logged in");
		SceneManager.LoadScene (1);
	}

	private void OnRegisterResult(RegisterPlayFabUserResult createResult){
		Debug.Log ("You made an account");
	}

	private void OnPlayFabError(PlayFabError error){
		Debug.Log ("Something went wrong");
		Debug.LogError (error.GenerateErrorReport ());
	}
}
