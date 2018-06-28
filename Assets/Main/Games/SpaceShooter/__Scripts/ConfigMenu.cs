using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class ConfigMenu : MonoBehaviour
{
    public Button enemiesGameButton;
    public Button audioGameButton;
    public Button backgroundGameButton;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    //color the buttons, give function to single player button
    void Awake()
    {
        enemiesGameButton.image.color = Color.magenta;
        audioGameButton.image.color = Color.grey;
        backgroundGameButton.image.color = Color.yellow;
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
    public void EnemyMenu()
    {
        SceneManager.LoadScene("_EnemiesMenu");

    }

    public void AudiosMenu()
    {
        SceneManager.LoadScene("_AudioMenu");

    }

    public void BackgroundsMenu()
    {
        SceneManager.LoadScene("_BackgroundMenu");

    }
    //Pauses in unity
    public void Exit()
    {
        SceneManager.LoadScene("_SecondMenu");
    }
}
