using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AudioMenu : MonoBehaviour
{
	
    public Dropdown audiomenuDropdown;
	public Slider volumeSlider;
    //public Dropdown audioVictorymenuDropdown;
    public Button exitButton;
    // Use this for initialization

    void Start()
    {
		audiomenuDropdown.value = GameManager.dropValue;
		volumeSlider.value = GameManager.audioValue;
		if (MenuHubScript.eButton == false) {
			Destroy (exitButton.gameObject);
		}
		//MenuHubScript.eButton);
		//print ("Menu value [" + MenuHubScript.eButton + "]");
    }
		
		
    // Update is called once per frame
    void Update()
    {
			GameManager.audioValue = volumeSlider.value;
            switch (audiomenuDropdown.value)
            {

                case 0:
                    GameManager.dropValue = 0;
                    break;
                case 1:
                    GameManager.dropValue = 1;
                    break;
                case 2:
                    GameManager.dropValue = 2;
                    break;
                default:
                    break;
            }
            /*switch (audioVictorymenuDropdown.value)
            {

                case 0:
                    GameManager.vicDropValue = 0;
                    break;
                case 1:
                    GameManager.vicDropValue = 1;
                    break;
                default:
                    break;
            }*/


    }
    public void Back()
    {
        SceneManager.LoadScene("_Config");
    }

}