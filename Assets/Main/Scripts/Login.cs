using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	public GameObject passScreen;
	private string Username;
	private string Password;
	private string[] Lines;
	private string DecryptedPass;
	private string adminInfo = "admin";

	public void LoginButton(){
		bool UN = false;
		bool PW = false;
		bool AMUN = false;
		bool AMPW = false;
		if (Username != "") {
			if (System.IO.File.Exists (@Application.dataPath + "/Users/" + Username + ".txt")) {
				UN = true;
				if (Username == adminInfo) {
					AMUN = true;
				}
				Lines = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + Username + ".txt");
			} else {
				Debug.LogWarning ("Username Not Found");
			}
		} else {
			Debug.LogWarning ("Username Field Empty");
		}
		if(Password != ""){
			if (System.IO.File.Exists (@Application.dataPath + "/Users/" + Username + ".txt")) {
				int i = 1;
				foreach (char c in Lines[1]) {
					i++;
					char Decrypted = (char)(c / i);
					DecryptedPass += Decrypted.ToString (); 
				}
				if (Password == DecryptedPass) {
					PW = true;
					if (DecryptedPass == adminInfo) {
						AMPW = true;
					}
				} else {
					//print (Password);
					//print (DecryptedPass);
					Debug.LogWarning ("Password incorrect!");
					//print (Password);
					//print (DecryptedPass);
					password.GetComponent<InputField>().text = "";
					Password = "";
					DecryptedPass = "";
				}
			} else {
				Debug.LogWarning ("Username Not Found");
			}
		} else {
			Debug.LogWarning ("Password Field Empty");
		}
		if(UN == true && PW == true){
			PlayerPrefs.SetString ("User", Username);
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			print ("Login Succesful");
			print (PlayerPrefs.GetString("User"));
			if (AMUN == true && AMPW == true) {
				//print ("this happened");
				passScreen.SetActive(true);

			} else {
				SceneManager.LoadScene ("HubScene");
			}
			//SceneManager.LoadScene ("HubScene");
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused) {
				password.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			if(Username != "" && Password != ""){
				LoginButton ();
			}
		}

		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
	}
}
