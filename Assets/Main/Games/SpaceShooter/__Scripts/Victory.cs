using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class Victory : MonoBehaviour
{
    public Button continueGameButton;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    //color the buttons, give function to single player button
    void Awake()
    {
        
        continueGameButton.image.color = Color.green;
        randomM = Random.Range(1, 4);
        randomS = Random.Range(1, 4);
        exitButton.image.color = Color.red;
        /*switch (GameManager.vicDropValue)
        {

            case 0:
                GameManager.GameHandler.audioM.PlayOneShot(GameManager.vic1);
                break;
            case 1:
                audioM.PlayOneShot(vic2);
                break;
            default:
                break;
        }*/
    }

    void Start()
    {

    }


    void Update()
    {

        if (randomM == randomS)
        {
            SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.sceneLoaded);
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
    //Singleplayer Works, did not make multiplayer portion
    public void Continue()
    {
        SceneManager.LoadScene("_GameLevels");

    }
    //Pauses in unity
    public void Exit()
    {
        SceneManager.LoadScene("Quit");
        Application.Quit();
    }
}