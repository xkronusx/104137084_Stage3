using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class GameLevels : MonoBehaviour
{
    public Button bronzeGameButton;
    public Button silverGameButton;
    public Button goldGameButton;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    //color the buttons, give function to single player button
    void Awake()
    {
        bronzeGameButton.image.color = Color.magenta;
        silverGameButton.image.color = Color.grey;
        goldGameButton.image.color = Color.yellow;
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
    public void BronzeGame()
    {
        SceneManager.LoadScene("_LevelBronze");

    }

    public void SilverGame()
    {
        SceneManager.LoadScene("_Scene_0");

    }

    public void GoldGame()
    {
        SceneManager.LoadScene("_Scene_0");

    }
    //Pauses in unity
    public void Exit()
    {
        SceneManager.LoadScene("_SecondMenu");
    }
}
