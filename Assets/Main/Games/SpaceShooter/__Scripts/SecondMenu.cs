using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class SecondMenu : MonoBehaviour
{
    public Button startGameButton;
    public Button gameLevelButton;
    public Button gameConfigButton;
    public Button gameHistoryButton;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    //color the buttons, give function to single player button
    void Awake()
    {
        startGameButton.image.color = Color.green;
        gameLevelButton.image.color = Color.blue;
        gameConfigButton.image.color = Color.blue;
        gameHistoryButton.image.color = Color.black;
        randomM = Random.Range(1, 4);
        randomS = Random.Range(1, 4);
        exitButton.image.color = Color.red;

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
    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");

    }

    public void GameLevels()
    {
        SceneManager.LoadScene("_GameLevels");

    }

    public void ConfigsMenu()
    {
        SceneManager.LoadScene("_Config");

    }
    //Pauses in unity
    public void Exit()
    {
        SceneManager.LoadScene("Quit");
        Application.Quit();
    }
}
