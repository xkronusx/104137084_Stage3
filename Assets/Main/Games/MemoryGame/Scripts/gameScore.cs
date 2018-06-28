using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScore : MonoBehaviour {
    /*
        public const int _score = 1000;

        public int currScore
        {
            get { return _score; }
            set { _score = value; }
        }
        */
    public Text endgameText;
    void Update(){
		endgameText.text = "Time: " + PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MTime") + " Score: " + PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MScore");
		//PlayerPrefs.SetString((PlayerPrefs.GetString ("User")+".MTime"), (gameTime.ToString("F1")));
		//PlayerPrefs.SetString((PlayerPrefs.GetString ("User")+".MScore"), (currentScore.ToString("F2")));

		//PlayerPrefs.GetInt (PlayerPrefs.GetString ("User") + ".HighScore");
		//print("testing4 [" + PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MScore") + "]");
		//print("testing5 [" + PlayerPrefs.GetInt(PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MScore")) + "]");
		if (int.Parse(PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MScore")) > PlayerPrefs.GetInt(PlayerPrefs.GetString ("User")+".MHighScore"))
		{
			PlayerPrefs.SetInt (PlayerPrefs.GetString ("User")+".MHighScore", int.Parse(PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MScore")));
			string[] Lines = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString ("User") + ".txt");
			Lines [3] = PlayerPrefs.GetInt (PlayerPrefs.GetString ("User")+".MHighScore").ToString();
			System.IO.File.WriteAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString("User") + ".txt", Lines);
			//System.IO.File.WriteAllText (@Application.dataPath + "/Users/" + Username + ".txt", form);
		}
    }

}
