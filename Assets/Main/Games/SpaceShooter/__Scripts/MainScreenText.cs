using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainScreenText : MonoBehaviour
{

    public AudioClip gameVictory;
    public AudioClip gameLose;
    public Text scoreTimeText;
    public Text enemyCountText;
    public static int currentScore = 0;
    public static int totalScore = 0;
    private float gameTime = 0.0f;
    public float endTime;
	public int highscore;

	void Awake()
	{
		// If the PlayerPrefs HighScore already exists, read it
		if (PlayerPrefs.HasKey(PlayerPrefs.GetString ("User")+".HighScore"))
		{
			highscore = PlayerPrefs.GetInt(PlayerPrefs.GetString ("User")+".HScore");
		}
	}

    void Update()
    {
        gameTime += Time.deltaTime;
        endTime = gameTime;
		scoreTimeText.text = "Level Score: " + currentScore + "          Time: " + gameTime.ToString("F1") + "  TOTAL Score: " + totalScore + "     HIGHSCORE:" + highscore;
        PlayerPrefs.SetString("User"+".Time", (gameTime.ToString("F1")));
        PlayerPrefs.SetString("User"+".Score", (currentScore.ToString("F2")));
        PlayerPrefs.SetString("User"+".Score", (totalScore.ToString("F2")));
		if (totalScore > highscore) {
			highscore = totalScore;
		}
		//print("Testing1[" + PlayerPrefs.GetInt (PlayerPrefs.GetString ("User")+".HScore") + "]");
		//print("Testing2[" + PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".HScore") + "]");

		if (highscore > PlayerPrefs.GetInt (PlayerPrefs.GetString ("User")+".HScore")) {
			PlayerPrefs.SetInt(PlayerPrefs.GetString ("User")+".HScore", highscore);
			string[] Lines = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString ("User") + ".txt");
			Lines[5] = PlayerPrefs.GetInt(PlayerPrefs.GetString ("User")+".HScore").ToString();
			System.IO.File.WriteAllLines (@Application.dataPath + "/Users/" + PlayerPrefs.GetString("User") + ".txt", Lines);
		}

    }
}