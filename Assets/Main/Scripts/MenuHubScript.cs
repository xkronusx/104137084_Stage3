using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuHubScript : MonoBehaviour {
	GameObject[] GMenu;
	bool qSwitch = true;
	public static bool eButton = true;
	public Canvas canvasMenu;
	public GameObject adminItem;
	public GameObject adminItem2;
	public GameObject adminItem3;
	public GameObject dUser;
	private string dUsername;
	public Text UserText;
	void Start(){
		GMenu = GameObject.FindGameObjectsWithTag("MenuHub");
		if (PlayerPrefs.GetString ("User") == "admin") {
			//adminItem.SetActive(true);
			adminItem2.SetActive(true);
			adminItem3.SetActive(true);
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			qSwitch = !qSwitch;
			//print ("value of switch[" + qSwitch + "]");
			//GMenu[0].gameObject.SetActive (qSwitch);
			canvasMenu.enabled = qSwitch;
		}
		//print ("Outside value of switch[" + qSwitch + "]");
	}
	public void StartAppleGame()
	{
		qSwitch = !qSwitch;
		canvasMenu.enabled = qSwitch;
		//DontDestroyOnLoad(transform.gameObject);
		if (GMenu.Length > 1)
		{
			//print ("Testing[" + this + "]");	
			Destroy(this.gameObject);
		}
		//print ("Testing[" + objs[0] + "]");
		DontDestroyOnLoad(GMenu[0].gameObject);

		//GMenu[0].gameObject.SetActive (false);
		SceneManager.LoadScene("ApplepickerScene");
	}
	public void AppleHistory()
	{
		SceneManager.LoadScene("HubScene");
	}


	public void StartMemoryGame()
	{
		qSwitch = !qSwitch;
		canvasMenu.enabled = qSwitch;
		if (GMenu.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(GMenu[0].gameObject);
		SceneManager.LoadScene("Menu");
	}
	public void MemGameHistory()
	{
		SceneManager.LoadScene("HubScene");
	}


	public void StartRPCGame()
	{
		qSwitch = !qSwitch;
		canvasMenu.enabled = qSwitch;
		if (GMenu.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(GMenu[0].gameObject);
		SceneManager.LoadScene("RPSMainMenu");
	}
	public void RPCGameHistory()
	{
		SceneManager.LoadScene("HubScene");
	}


	public void StartSpaceShooter()
	{
		qSwitch = !qSwitch;
		canvasMenu.enabled = qSwitch;
		if (GMenu.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(GMenu[0].gameObject);
		eButton = true;
		SceneManager.LoadScene("_MainScene");
	}
	public void SpaceShooterHistory()
	{
		SceneManager.LoadScene("HubScene");
	}
	public void SpaceShooterEnemies()
	{
		qSwitch = !qSwitch;
		canvasMenu.enabled = qSwitch;
		if (GMenu.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(GMenu[0].gameObject);
		eButton = false;
		SceneManager.LoadScene("_EnemiesMenu");
	}

	public void SpaceShooterAudio()
	{
		qSwitch = !qSwitch;
		canvasMenu.enabled = qSwitch;
		if (GMenu.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(GMenu[0].gameObject);
		eButton = false;
		SceneManager.LoadScene("_AudioMenu");

	}

	public void SpaceShooterBackground()
	{
		qSwitch = !qSwitch;
		canvasMenu.enabled = qSwitch;
		if (GMenu.Length > 1)
		{
			Destroy(this.gameObject);
		}
		eButton = false;
		DontDestroyOnLoad(GMenu[0].gameObject);
		SceneManager.LoadScene("_BackgroundMenu");
	}

	public void deleteUser(){
			UserText.text = " ";
			DirectoryInfo dir = new DirectoryInfo (@Application.dataPath + "/Users/");
			FileInfo[] info = dir.GetFiles ("*.txt");
			foreach (FileInfo f in info) {
			//print (Path.GetFileNameWithoutExtension (f.FullName));
			//string[] Liness = System.IO.File.ReadAllLines (@Application.dataPath + "/Users/" + Path.GetFileNameWithoutExtension (f.FullName) + ".txt");
			UserText.text += "\nUser: " + Path.GetFileNameWithoutExtension (f.FullName) + "\n";	
			}
		}
	public void deleteUserConf(){
		dUsername = dUser.GetComponent<InputField>().text;
		if (dUsername != "") {
			if (dUsername != "admin") {
				if(System.IO.File.Exists (@Application.dataPath + "/Users/" + dUsername + ".txt")){
					File.Delete (@Application.dataPath + "/Users/" + dUsername + ".txt");
					dUser.GetComponent<InputField> ().text = "";
				}
			}
		}
	}



	public void ExitCurrentGame()
	{
		Destroy(GMenu[0].gameObject);
		GameObject[] objs = GameObject.FindGameObjectsWithTag("GameHandler");
		if (objs.Length > 0)
		{
			//print (this.gameObject);
			Destroy(objs[0].gameObject);
		}
		eButton = true;
		SceneManager.LoadScene("HubScene");
	}
}
