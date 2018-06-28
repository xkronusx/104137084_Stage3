using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MemoryGameManager : MonoBehaviour {

    public AudioClip gameVictory;
    public AudioClip gameLose;
    public AudioClip cardMatchSound;
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;
    public Text timerText;
    public int currentScore = 1000;
    private bool _init = false;
    //private int _matches = 10;
    static private int _matches;
    private float gameTime = 0.0f;
    public float endTime;
    void Update () {
        gameTime += Time.deltaTime;
        
        if (!_init)
        {
            initializeCards();
        }
        if(Input.GetMouseButtonUp(0)){
            checkCards();
        }
        endTime = gameTime;
        timerText.text = "Time: " + gameTime.ToString("F1");
		PlayerPrefs.SetString(PlayerPrefs.GetString ("User")+".MTime", gameTime.ToString("F1"));
		PlayerPrefs.SetString(PlayerPrefs.GetString ("User")+".MScore", currentScore.ToString());
		//print ("Testing[" + PlayerPrefs.GetString(PlayerPrefs.GetString ("User") + ".MTime") + "]");
		//print ("Testing[" + PlayerPrefs.GetString ("User") + "]");
		//print ("Testing2[" + PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MScore") + "]");
		//print ("Testing3[" + PlayerPrefs.GetString(PlayerPrefs.GetString ("User")+".MTime") + "]");
    }

    void initializeCards()
    {
		MemoryGameManager._matches = (cards.Length/2);
        int a = ((cards.Length/2) + 1);
        
        for (int id = 0; id < 2; id++)
        {
            for(int i = 1; i < a; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
            }
        }
        foreach(GameObject c in cards)
        {
            c.GetComponent<Card>().setupGraphics();
        }
        if (!_init)
        {
            _init = true;
        }
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 1)
                c.Add(i);
        }
            if (c.Count == 2)
                cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        matchText.text = "Number of Matches: " + _matches + " Score: " + currentScore;

        Card.DO_NOT = true;
        int x = 0;
        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Number of Matches: " + _matches + " Score: " + currentScore;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(cardMatchSound);
            if (_matches == 0)
                SceneManager.LoadScene("Win");
                audio.PlayOneShot(gameVictory);
        }
        else if((cards[c[0]].GetComponent<Card>().cardValue != cards[c[1]].GetComponent<Card>().cardValue))
        {
            currentScore -= 40;
            matchText.text = "Number of Matches: " + _matches + " Score: " + currentScore;
            if (currentScore == 0)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(gameLose);
                SceneManager.LoadScene("Lose");
                
            }

        }
        for(int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }
}

