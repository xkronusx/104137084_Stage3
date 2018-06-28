using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

	public class ChangePass : MonoBehaviour {

		public GameObject cPassword;
		public GameObject cPassword2;


		private string CPass;
		private string CPass2;
		public void cPassButton(){
		print ("test");
		print (CPass);
		print (CPass2);
			bool cPN = false;
			bool cPW = false;

			if (CPass != "") {
			cPN = true;
			} else {
				Debug.LogWarning ("First field Empty");
			}
			if (CPass2 != "") {
				if (CPass2.Length > 4) {
					cPW = true;
				} else {
					Debug.LogWarning ("Password Must Be Longer than 5 Characters and match!");
				}
			} else {
				Debug.LogWarning ("Password Field Empty");
			}
			if (cPN == true && cPW == true) {
				bool Clear = true;
				int i = 1;
				foreach (char c in CPass2) {
					if (Clear) {
						CPass2 = "";
						Clear = false;
					}
					i++;
					char Encrypted = (char)(c * i);
					CPass2 += Encrypted.ToString(); 
				}
				string[] Lines = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString("User") + ".txt");
				Lines [1] = CPass2;
				//USE IF EXECUTING FROM TEST ENVIRONMENT 
				System.IO.File.WriteAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString("User") + ".txt", Lines);

				//USE IF EXECUTING FILE FROM EXE
				//System.IO.File.WriteAllText ("/Users/" + Username + ".txt", form);
				cPassword.GetComponent<InputField>().text = "";
				cPassword2.GetComponent<InputField>().text = "";
				print ("Registration Complete");
				SceneManager.LoadScene ("Login Scene");
			}

		}

		// Update is called once per frame
		void Update (){
			if (Input.GetKeyDown(KeyCode.Tab)){
				if (cPassword.GetComponent<InputField>().isFocused) {
					cPassword2.GetComponent<InputField>().Select();
				}
				/*if (password.GetComponent<InputField> ().isFocused) {
				Login.GetComponent<InputField> ().Select();
			}*/
			}
			if (Input.GetKeyDown(KeyCode.Return)){
			if(CPass != "" && CPass2 != ""){
					cPassButton ();
				}
			}
			CPass = cPassword.GetComponent<InputField>().text;
			CPass2 = cPassword2.GetComponent<InputField>().text;
		}
	}