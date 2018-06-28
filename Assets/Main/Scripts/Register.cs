using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject password;

	private string Username;
	private string Password;

	private string form;
	private string form2;

	public void RegisterButton(){
		bool UN = false;
		bool PW = false;

		if (Username != "") {
			if (!System.IO.File.Exists (@Application.dataPath + "/Users/" + Username + ".txt")) {
				UN = true;
			} else {
				//Application.Quit();
				Debug.LogWarning ("Username taken");
				username.GetComponent<InputField>().text = "";
				password.GetComponent<InputField>().text = "";
			}
		} else {
			Debug.LogWarning ("Username field Empty");
		}
		if (Password != "") {
			if (Password.Length > 4) {
				PW = true;
			} else {
				Debug.LogWarning ("Password Must Be Longer than 5 Characters!");
			}
		} else {
			Debug.LogWarning ("Password Field Empty");
		}
		if (UN == true && PW == true) {
			bool Clear = true;
			int i = 1;
			foreach (char c in Password) {
				if (Clear) {
					Password = "";
					Clear = false;
				}
				i++;
				char Encrypted = (char)(c * i);
				Password += Encrypted.ToString(); 
			}
			form = (Username +Environment.NewLine+ Password+Environment.NewLine+Environment.NewLine+Environment.NewLine+Environment.NewLine+Environment.NewLine+Environment.NewLine);
			//USE IF EXECUTING FROM TEST ENVIRONMENT 
			System.IO.File.WriteAllText (@Application.dataPath + "/Users/" + Username + ".txt", form);
			print (@Application.dataPath + "/Users/" + Username + ".txt");

			//USE IF EXECUTING FILE FROM EXE
			//System.IO.File.WriteAllText ("/Users/" + Username + ".txt", form);

			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			print ("Registration Complete");

		}
	}

	// Update is called once per frame
	void Update (){
		if (!Directory.Exists (Application.dataPath + "/Users/")) {
			Directory.CreateDirectory(Application.dataPath + "/Users/");
			form2 = "admin" + Environment.NewLine + "ÂĬƴȍʔ" + Environment.NewLine+Environment.NewLine+Environment.NewLine+Environment.NewLine+Environment.NewLine+Environment.NewLine+Environment.NewLine;
			System.IO.File.WriteAllText (Application.dataPath + "/Users/" + "admin" + ".txt", form2);
			string usern = "admin";
			PlayerPrefs.SetString ("User", usern);
		}
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused) {
				password.GetComponent<InputField>().Select();
			}
			/*if (password.GetComponent<InputField> ().isFocused) {
				Login.GetComponent<InputField> ().Select();
			}*/
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			if(Username != "" && Password != ""){
				RegisterButton ();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
	}
}
