using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginWithPlayfab : MonoBehaviour {

	//Log in Boxes
	[Header("Log in Text Fields")]
	public InputField usernameBox;
	public InputField passwordBox;

	//Register Boxes
	[Header("Register Text Fields")]
	public InputField accountName;
	public InputField displayName;
	public InputField emailBox;
	public InputField createPassword;
	public InputField confirmPassword;



	//Private Variables
	private string titleid = "B613";
	private string password;
	private string username;
	private string createdPassword;
	private string confirmedPassword;
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
		createdPassword = createPassword.text;
		confirmedPassword = confirmPassword.text;
		if (createdPassword == confirmedPassword) {
			RegisterPlayFabUserRequest create = new RegisterPlayFabUserRequest ();
			create.Username = accountName.text;
			create.Email = emailBox.text;
			create.Password = createdPassword;
			create.DisplayName = displayName.text;
			create.TitleId = titleid;
			PlayFabClientAPI.RegisterPlayFabUser (create, OnRegisterResult, OnPlayFabError);
		} else {
			Debug.LogError ("Passwords Must Match");
		}
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
