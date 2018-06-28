using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public AudioClip first1;
    public AudioClip second2;
    public AudioClip third3;
    public AudioClip vic1;
    public AudioClip vic2;
    public AudioSource audioM;
    int togglenum = 3;
    public static int dropValue = 0;
	public static float audioValue = 1.0f;
    public static int vicDropValue = 0;
    public static int backValue = 0;
    public Texture[] textures;
    // Use this for initialization
	public static int enemy0dropValue = 0;
	public static int enemy0dropValueScore;
	public static int enemy0dropValuec = 0;
	public static string enemy0dropValueScorec;
	public static int enemy1dropValue = 0;
	public static int enemy1dropValueScore;
	public static int enemy1dropValuec = 0;
	public static int enemy2dropValue = 0;
	public static int enemy2dropValueScore;
	public static int enemy3dropValue = 0;
	public static int enemy3dropValueScore;
	public static int enemy4dropValue = 0;
	public static int enemy4dropValueScore;
    public static bool enemyN0 = true;
    public static bool enemyN1 = true;
    public static bool enemyN2 = true;
    public static bool enemyN3 = true;
    public static bool enemyN4 = true;
    public static int bScore = 100;
    public static int enNum = 10;
    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameHandler");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
		audioM.volume = audioValue;
        //audio = GetComponent<AudioSource>();
        if (dropValue != togglenum)
        {
            switch (dropValue)
            {

                case 0:
                    //m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
                    //audio.PlayOneShot(first1);
                    //audioM.Play();
                    audioM.Stop();
                    audioM.clip = first1;
                    audioM.Play();
                    togglenum = 0;
                    break;
                case 1:
                    //AudioSource audio = GetComponent<AudioSource>();
                    //audio.Stop();
                    //audio.PlayOneShot(second2);
                    audioM.clip = second2;
                    audioM.Play();
                    togglenum = 1;
                    // m_Renderer.material.SetTexture("_BumpMap", m_Normal);
                    break;
                case 2:
                    //AudioSource audio3 = GetComponent<AudioSource>();
                    //audio.Stop();
                    //audio.PlayOneShot(third3);
                    //m_Renderer.material.SetTexture("_MetallicGlossMap", m_Metal);
                    audioM.clip = third3;
                    audioM.Play();
                    togglenum = 2;
                    break;
                default:
                    break;
            }
        }
        switch (backValue)
        {

            case 0:
                GameObject.Find("StarfieldBG").GetComponent<Renderer>().material.mainTexture = this.textures[0];
                break;
            case 1:
                GameObject.Find("StarfieldBG").GetComponent<Renderer>().material.mainTexture = this.textures[1];
                break;
            case 2:
                GameObject.Find("StarfieldBG").GetComponent<Renderer>().material.mainTexture = this.textures[2];
                break;
            default:
                break;
        }
		switch (enemy0dropValue) {
		case 0: 
			enemy0dropValueScore = 5;
			break;
		case 1: 
			enemy0dropValueScore = 25;
			break;
		case 2: 
			enemy0dropValueScore = 50;
			break;
		}
		/*
		switch (enemy0dropValuec) {
		case 0: 
			enemy0dropValueScorec = "black";
			break;
		case 1: 
			enemy0dropValueScorec = "blue";
			break;
		case 2: 
			enemy0dropValueScorec = "red";
			break;
		}
		switch (enemy1dropValuec) {
		case 0: 
			enemy0dropValueScorec = "red";
			break;
		case 1: 
			enemy0dropValueScorec = "blue";
			break;
		case 2: 
			enemy0dropValueScorec = "black";
			break;
		}*/

		switch (enemy1dropValue) {
		case 0: 
			enemy1dropValueScore = 5;
			break;
		case 1: 
			enemy1dropValueScore = 25;
			break;
		case 2: 
			enemy1dropValueScore = 50;
			break;
		}
		switch (enemy2dropValue) {
		case 0: 
			enemy2dropValueScore = 5;
			break;
		case 1: 
			enemy2dropValueScore = 25;
			break;
		case 2: 
			enemy2dropValueScore = 50;
			break;
		}
		switch (enemy3dropValue) {
		case 0: 
			enemy3dropValueScore = 5;
			break;
		case 1: 
			enemy3dropValueScore = 25;
			break;
		case 2: 
			enemy3dropValueScore = 50;
			break;
		}
		switch (enemy4dropValue) {
		case 0: 
			enemy4dropValueScore = 5;
			break;
		case 1: 
			enemy4dropValueScore = 25;
			break;
		case 2: 
			enemy4dropValueScore = 50;
			break;
		}
    }

}