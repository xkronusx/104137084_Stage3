using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class MainMenu : MonoBehaviour
{
	//private Camera cam;
    public Button startGameButton;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    //color the buttons, give function to single player button
    void Awake()
    {
        startGameButton.image.color = Color.green;
        randomM = Random.Range(1, 4);
        randomS = Random.Range(1, 4);
        exitButton.image.color = Color.red;
      

    }
    void Start()
    {
		//cam = Camera.main;
		MainScreenText.currentScore = 0;
    }


    void Update()
    {
		/*if (Input.GetKey("space"))
		{
			// choose the margin randomly
			float margin = Random.Range(0.0f, 0.3f);
			// setup the rectangle
			cam.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);
			print (cam.rect);
		}*/

        if (randomM == randomS)
        {
            SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.sceneLoaded);
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
    //Singleplayer Works, did not make multiplayer portion
    public void StartGame()
    {
        SceneManager.LoadScene("_SecondMenu");
        
    }
    //Pauses in unity
    public void Exit()
    {
        SceneManager.LoadScene("Quit");
        Application.Quit();
    }
}
