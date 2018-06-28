using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class History : MonoBehaviour {
	public Text HistoryText;
	static int historyValue;
	//int i = 0;
	// Use this for initialization
	void Start () {
	}
	public void SetHistoryValue(int valueH){
		historyValue = valueH;
	}
	
	// Update is called once per frame
	void Update () {
		string[] Lines = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString ("User") + ".txt");
		switch(historyValue){
			case 0:
			if(PlayerPrefs.GetString ("User") != "admin"){
				HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nApplePicker Score: " + Lines [2];
				}
			if (PlayerPrefs.GetString ("User") == "admin") {
					//HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nApplePicker Score: " + Lines [2];
					HistoryText.text = " ";
					DirectoryInfo dir = new DirectoryInfo (@Application.dataPath + "/Users/");
					FileInfo[] info = dir.GetFiles ("*.txt");
					foreach (FileInfo f in info) {
						print (Path.GetFileNameWithoutExtension (f.FullName));
						string[] Liness = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + Path.GetFileNameWithoutExtension (f.FullName) + ".txt");
						HistoryText.text += "\nUser: " + Path.GetFileNameWithoutExtension (f.FullName) + "\nApplePicker Score: " + Liness [2] + "\n";	
						//print ("\nUser: " + Path.GetFileNameWithoutExtension (f.FullName) + "\nApplePicker Score: " + Liness [2]);
						//print ("["+f+"]");
					}
					
				}
				/*
				var info = new DirectoryInfo(path);
				var fileInfo = info.GetFiles();
				for (file f in fileInfo) print (file);*/
				break;
		case 1:
				if (PlayerPrefs.GetString ("User") != "admin") {
					HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nMemoryGame Score: " + Lines [3];
				}
				if (PlayerPrefs.GetString ("User") == "admin") {
					//HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nMemoryGame Score: " + Lines [3];
					HistoryText.text = " ";
					DirectoryInfo dir = new DirectoryInfo (@Application.dataPath + "/Users/");
					FileInfo[] info = dir.GetFiles ("*.txt");
					foreach (FileInfo f in info) {
						print (Path.GetFileNameWithoutExtension (f.FullName));
						string[] Liness = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + Path.GetFileNameWithoutExtension (f.FullName) + ".txt");
						HistoryText.text += "\nUser: " + Path.GetFileNameWithoutExtension (f.FullName) + "\nMemoryGame Score: " + Liness [3] + "\n";	
					}
				}
				break;
			case 2:
			if (PlayerPrefs.GetString ("User") != "admin") {
				HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nRockPaperScissors Score: " + Lines [4];
			}
			if (PlayerPrefs.GetString ("User") == "admin") {
				HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nRockPaperScissors Score: " + Lines [4];
				DirectoryInfo dir = new DirectoryInfo (@Application.dataPath + "/Users/");
				FileInfo[] info = dir.GetFiles ("*.txt");
				foreach (FileInfo f in info) {
					print (Path.GetFileNameWithoutExtension (f.FullName));
					string[] Liness = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + Path.GetFileNameWithoutExtension (f.FullName) + ".txt");
					HistoryText.text += "\nUser: " + Path.GetFileNameWithoutExtension (f.FullName) + "\nRockPaperScissors Score: " + Liness [4] + "\n";	
				}
			}
				break;
			case 3:
			if (PlayerPrefs.GetString ("User") != "admin") {
				HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nSpace Shooter Score: " + Lines [5];
			}
			if (PlayerPrefs.GetString ("User") == "admin") {
				//HistoryText.text = "User: " + PlayerPrefs.GetString ("User") + "\nSpace Shooter Score: " + Lines [5];
				HistoryText.text = " ";
				DirectoryInfo dir = new DirectoryInfo (@Application.dataPath + "/Users/");
				FileInfo[] info = dir.GetFiles ("*.txt");
				foreach (FileInfo f in info) {
					print (Path.GetFileNameWithoutExtension (f.FullName));
					string[] Liness = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + Path.GetFileNameWithoutExtension (f.FullName) + ".txt");
					HistoryText.text += "\nUser: " + Path.GetFileNameWithoutExtension (f.FullName) + "\nSpace Shooter Score: " + Liness [5] + "\n";	
				}
			}
				break;
			default:
				break;
		}
	}
}
