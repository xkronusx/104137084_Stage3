using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class RPCMainMenu : MonoBehaviour {
    public Button singlePlayerButton;
    public Button multiPlayerButton;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    //color the buttons, give function to single player button
    void Awake()
    {
        singlePlayerButton.image.color = Color.green;
        multiPlayerButton.image.color = Color.green;
        randomM = Random.Range(1, 4);
        randomS = Random.Range(1, 4);
        exitButton.image.color = Color.red;

    }
	void Start () {
		
	}
	
	
	void Update () {

        if(randomM == randomS)
        {
            SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.sceneLoaded);
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
    //Singleplayer Works, did not make multiplayer portion
    public void SinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
        //Application.LoadLevel("SinglePlayer");
    }
    public void MultiPlayer()
    {
        SceneManager.LoadScene("MultiPlayer");
        //Application.LoadLevel("MultiPlayer");
    }
    //Pauses in unity
    public void Quit()
    {
        SceneManager.LoadScene("Quit");
        Application.Quit();
    }
}
