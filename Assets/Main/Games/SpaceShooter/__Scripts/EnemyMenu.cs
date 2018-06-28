using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class EnemyMenu : MonoBehaviour
{
    /*public Button enemy1Button;
    public Button enemy2Button;
    public Button enemy3Button;
    public Button enemy4Button;
    public Button enemy5Button;*/
    public Button exitButton;
    int randomS; int randomM; int randomE;
    //public InputField enemyNumberInput;
    //public bool textEntered;
	public Dropdown enemy0menuDropdown;
	public Dropdown enemy0menuDropdownc;
	public Dropdown enemy1menuDropdown;
	public Dropdown enemy1menuDropdownc;
	public Dropdown enemy2menuDropdown;
	public Dropdown enemy2menuDropdownc;
	public Dropdown enemy3menuDropdown;
	public Dropdown enemy3menuDropdownc;
	public Dropdown enemy4menuDropdown;
	public Dropdown enemy4menuDropdownc;
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
		if (MenuHubScript.eButton == false) {
			Destroy (exitButton.gameObject);
		}
    }

    public void SaveEnemyValue(string enemyNumber)
    {
        /*textEntered = true;*/
        PlayerPrefs.SetString("numEnemy", enemyNumber);
    }

    void Update()
    {

        if (randomM == randomS)
        {
            SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.sceneLoaded);
            //Application.LoadLevel(Application.loadedLevel);
        }
		switch (enemy0menuDropdown.value)
		{

		case 0:
			GameManager.enemy0dropValue = 0;
			break;
		case 1:
			GameManager.enemy0dropValue = 1;
			break;
		case 2:
			GameManager.enemy0dropValue = 2;
			break;
		default:
			break;
		}
		switch (enemy0menuDropdownc.value)
		{

		case 0:
			GameManager.enemy0dropValue = 0;
			break;
		case 1:
			GameManager.enemy0dropValue = 1;
			break;
		case 2:
			GameManager.enemy0dropValue = 2;
			break;
		default:
			break;
		}


		switch (enemy1menuDropdown.value)
		{

		case 0:
			GameManager.enemy1dropValue = 0;
			break;
		case 1:
			GameManager.enemy1dropValue = 1;
			break;
		case 2:
			GameManager.enemy1dropValue = 2;
			break;
		default:
			break;
		}
		switch (enemy2menuDropdown.value)
		{

		case 0:
			GameManager.enemy2dropValue = 0;
			break;
		case 1:
			GameManager.enemy2dropValue = 1;
			break;
		case 2:
			GameManager.enemy2dropValue = 2;
			break;
		default:
			break;
		}
		switch (enemy3menuDropdown.value)
		{

		case 0:
			GameManager.enemy3dropValue = 0;
			break;
		case 1:
			GameManager.enemy3dropValue = 1;
			break;
		case 2:
			GameManager.enemy3dropValue = 2;
			break;
		default:
			break;
		}
		switch (enemy4menuDropdown.value)
		{

		case 0:
			GameManager.enemy4dropValue = 0;
			break;
		case 1:
			GameManager.enemy4dropValue = 1;
			break;
		case 2:
			GameManager.enemy4dropValue = 2;
			break;
		default:
			break;
		}
    }
    //Pauses in unity

    public void Toggle_Changed(bool newValue)
    {

    }
    public void Back()
    {
        SceneManager.LoadScene("_Config");
        //Application.Quit();
    }
}