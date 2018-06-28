using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour {

	public void triggerMenuBehavior(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("Level");
                break;
            case (1):
                Application.Quit();
                break;
            case (2):
                SceneManager.LoadScene("Menu2");
                break;
            case (3):
                SceneManager.LoadScene("Level");
                break;
            case (4):
                SceneManager.LoadScene("Level2");
                break;
            case (5):
                SceneManager.LoadScene("Level3");
                break;
            case (6):
                SceneManager.LoadScene("Menu");
                break;
            
        }
    }
}

