using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Making buttons and declaring variables
public class BackgroundMenu : MonoBehaviour
{
    public Texture[] textures;
    public Button exitButton;
    int randomS; int randomM; int randomE;
    public Dropdown backgroundDropdown;
    void Awake()
    {

        randomM = Random.Range(1, 4);
        randomS = Random.Range(1, 4);
        exitButton.image.color = Color.red;
		if (MenuHubScript.eButton == false) {
			Destroy (exitButton.gameObject);
		}
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

        switch (backgroundDropdown.value)
        {
            case 0:
                //m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
                //GameObject.Find("StarfieldBG").GetComponent<Renderer>().material.mainTexture = this.textures[0];
                GameManager.backValue = 0;
                break;
            case 1:
                //GameObject.Find("StarfieldBG").GetComponent<Renderer>().material.mainTexture = this.textures[1];
                GameManager.backValue = 1;
                // m_Renderer.material.SetTexture("_BumpMap", m_Normal);
                break;
            case 2:
                //GameObject.Find("StarfieldBG").GetComponent<Renderer>().material.mainTexture = this.textures[2];
                //m_Renderer.material.SetTexture("_MetallicGlossMap", m_Metal);
                GameManager.backValue = 2;
                break;
        }
    }
    //Pauses in unity


    public void Back()
    {
        SceneManager.LoadScene("_Config");
    }
}