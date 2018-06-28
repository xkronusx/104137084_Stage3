using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class LevelMenu : MonoBehaviour
{
    public Button enemy1Button;
    public Button enemy2Button;
    public Button enemy3Button;
    public Button enemy4Button;
    public Button enemy5Button;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    public InputField enemyNumberInput;
    public InputField scoreNumberInput;
    //public bool textEntered;
    void Awake()
    {
        /*enemy1Button.image.color = Color.green;
        enemy1Button.image.color = Color.blue;
        enemy1Button.image.color = Color.blue;
        enemy1Button.image.color = Color.blue;
        enemy1Button.image.color = Color.blue;*/
        randomM = Random.Range(1, 4);
        randomS = Random.Range(1, 4);
        exitButton.image.color = Color.red;

    }
    void Start()
    {
        /* if (textEntered == true)
         {
             enemyNumberInput.text = PlayerPrefs.GetString("numEnemy");
         }*/
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
    //Pauses in unity

    public void Toggle_Changed()
    {
        if (GameManager.enemyN0 == false)
        {
            //Debug.Log("enemy_0 false");
            GameManager.enemyN0 = true;
        }
        else
        {
            //Debug.Log("enemy_0 true");
            GameManager.enemyN0 = false;
        }
    }

    public void Toggle_Changed1()
    {
        if (GameManager.enemyN1 == false)
        {
            //Debug.Log("enemy_1 false");
            GameManager.enemyN1 = true;
        }
        else
        {
            //Debug.Log("enemy_1 true");
            GameManager.enemyN1 = false;
        }
    }

    public void Toggle_Changed2()
    {
        if (GameManager.enemyN2 == false)
        {
            //Debug.Log("enemy_2 false");
            GameManager.enemyN2 = true;
        }
        else
        {
            //Debug.Log("enemy_2 true");
            GameManager.enemyN2 = false;
        }
    }

    public void Toggle_Changed3()
    {
        if (GameManager.enemyN3 == false)
        {
            //Debug.Log("enemy_3 false");
            GameManager.enemyN3 = true;
        }
        else
        {
            //Debug.Log("enemy_3 true");
            GameManager.enemyN3 = false;
        }
    }

    public void Toggle_Changed4()
    {
        if (GameManager.enemyN4 == false)
        {
            //Debug.Log("enemy_4 false");
            GameManager.enemyN4 = true;
        }
        else
        {
            //Debug.Log("enemy_4 true");
            GameManager.enemyN4 = false;
        }
    }

    public void getEnemy()
    {
        GameManager.enNum = int.Parse(enemyNumberInput.text);

    }
    public void getScore()
    {
        GameManager.bScore = int.Parse(scoreNumberInput.text);

    }
    public void Back()
    {
        SceneManager.LoadScene("_GameLevels");
    }
}