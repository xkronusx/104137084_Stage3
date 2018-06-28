using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour {
    static public int score = 0;
    // Use this for initialization
    void Awake()
    {
        // If the PlayerPrefs HighScore already exists, read it
		if (PlayerPrefs.HasKey(PlayerPrefs.GetString ("User")+".HighScore"))
        {
			score = PlayerPrefs.GetInt(PlayerPrefs.GetString ("User")+".HighScore");
        }
    }

        // Update is called once per frame
        void Update () {
            Text gt = this.GetComponent<Text>();
            gt.text = "High Score: " +score;
            //Update the highscore if needed
			if (score > PlayerPrefs.GetInt(PlayerPrefs.GetString ("User")+".HighScore"))
            {
				PlayerPrefs.SetInt(PlayerPrefs.GetString ("User")+".HighScore", score);
				string[] Lines = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString ("User") + ".txt");
				Lines[2] = PlayerPrefs.GetInt(PlayerPrefs.GetString ("User")+".HighScore").ToString();
				System.IO.File.WriteAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString("User") + ".txt", Lines);
				//System.IO.File.WriteAllText (@Application.dataPath + "/Users/" + Username + ".txt", form);
            }
		//print (PlayerPrefs.GetInt (PlayerPrefs.GetString ("User")+".HighScore"));
    }
}
