using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour
{
	public int escore = 40;
    public static int enemyAllowScreen = GameManager.enNum;
    public static int enemyNumberScreen = 0;
    public int thing1 = 0;
    static public Main S; // A singleton for main
    static Dictionary<WeaponType, WeaponDefinition> WEAP_DICT;
    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies; //Array of enemy
    public float enemySpawnPerSecond = 0.5f; // enemies per second
    public float enemyDefaultPadding = 1.5f; // padding for position
    public WeaponDefinition[] weaponDefinitions;
    public GameObject prefabPowerUp;
    public WeaponType[] powerUpFrequency = new WeaponType[] {
                                               WeaponType.blaster, WeaponType.blaster,
                                               WeaponType.spread, WeaponType.shield};
    private BoundsCheck bndCheck;
	private Enemy eNemy;

    bool isPaused = false;
    static int en0 =-1, en1 =-1, en2 = -1, en3 = -1, en4 = -1;

    void OnGUI()
    {
        if (isPaused)
            GUI.Label(new Rect(200, 200, 150, 130), "Game paused");
    }

    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }

    public void shipDestroyed(Enemy e)
    {
        
        // Potentially generate a PowerUp
        if (Random.value <= e.powerUpDropChance)
        {
            // Choose which PowerUp to pick
            // Pick one from the possibilities in powerUpFrequency
            int ndx = Random.Range(0, powerUpFrequency.Length);
            WeaponType puType = powerUpFrequency[ndx];
            // Spawn a PowerUp
            GameObject go = Instantiate(prefabPowerUp) as GameObject;
            PowerUp pu = go.GetComponent<PowerUp>();
            // Set it to the proper WeaponType
            pu.SetType(puType);
            // Set it to the position of the destroyed ship
            pu.transform.position = e.transform.position;
        }
    }

    void Awake()
    {
        S = this;
        // Set bndCheck to reference Boundcheck component
        bndCheck = GetComponent<BoundsCheck>();
        //Spawn enemys once in 2 seconds with current value
        if (enemyNumberScreen < enemyAllowScreen)
        {
            Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
            enemyNumberScreen++;
        }
        WEAP_DICT = new Dictionary<WeaponType, WeaponDefinition>();
        foreach (WeaponDefinition def in weaponDefinitions)
        {
            WEAP_DICT[def.type] = def;
        }
    }
    void Update()
    {
        if(MainScreenText.currentScore > GameManager.bScore)
        {
            MainScreenText.currentScore = 0;
            SceneManager.LoadScene("_Victory");
        }
    }

    public void SpawnEnemy()
    {
        //pick random enemy prefab to instatiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        //int ndx = Random.Range(2,7);
        if (GameManager.enemyN0 == false) {
            en0 = 0;
                }
        if (GameManager.enemyN1 == false)
        {
            en1 = 1;
                }
        if (GameManager.enemyN2 == false)
        {
            en2 = 2;
                }
        if (GameManager.enemyN3 == false)
        {
            en3 = 3;
                }
        if (GameManager.enemyN4 == false)
        {
            en4 = 4;
                }
        while (ndx == en0 || ndx == en1 || ndx == en2 || ndx == en3 || ndx == en4){
            switch (ndx)
            {
                case 0:
                    if (GameManager.enemyN0 == false)
                    {

                        ndx = Random.Range(0, prefabEnemies.Length);
                    }
                    break;
                case 1:
                    if (GameManager.enemyN1 == false)
                    {
                        ndx = Random.Range(0, prefabEnemies.Length);
                    }
                    break;
                case 2:
                    if (GameManager.enemyN2 == false)
                    {
                        ndx = Random.Range(0, prefabEnemies.Length);
                    }
                    break;
                case 3:
                    if (GameManager.enemyN3 == false)
                    {
                        ndx = Random.Range(0, prefabEnemies.Length);
                    }
                    break;
                case 4:
                    if (GameManager.enemyN4 == false)
                    {
                        ndx = Random.Range(0, prefabEnemies.Length);
                    }
                    break;
            }
        }
			
		//gameObject.prefabEnemies [ndx].score = escore;
		switch (ndx)
		{
			case 0:
				prefabEnemies [0].GetComponent<Enemy> ().score = GameManager.enemy0dropValueScore;
				//GameManager.enemy0dropValueScorec = "blue";
				//GameManager.enemy0dropValueScorec = ;
				//prefabEnemies [0].GetComponent<Enemy> ().materials[0].color = Color.red;
				//GameObject.Find ("Enemy_0").GetComponent<Enemy> ().score = GameManager.enemy0dropValueScore;
				break;
			case 1:
				prefabEnemies [1].GetComponent<Enemy> ().score = GameManager.enemy1dropValueScore;
				//GameManager.enemy0dropValueScorec = "black";
				break;
			case 2:
				prefabEnemies [2].GetComponent<Enemy> ().score = GameManager.enemy2dropValueScore;
				break;
			case 3:
				prefabEnemies [3].GetComponent<Enemy> ().score = GameManager.enemy3dropValueScore;
				break;
			case 4:
				prefabEnemies [4].GetComponent<Enemy_4> ().score = GameManager.enemy4dropValueScore;
				//GameObject.Find ("Enemy_4(Clone)").GetComponent<Enemy> ().score = escore;
				break;
		}
		GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        // Position enemy above the screen with random x position
        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }
        // set the initial position for the spawned enemy
		//go.GetComponent<Enemy>()
		//print("Enemy[" + go + "]");
		//this.go.score = 10;
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        // invoke spawn again
        if (enemyNumberScreen < enemyAllowScreen) { 
            Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
            enemyNumberScreen++;
            thing1 = enemyNumberScreen;
        }
}

    public void DelayedRestart(float delay)
    {
        //start restart mnethod in delay seconds
		MainScreenText.currentScore = 0;
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        //Reload _Scene_0 to restart game
		enemyNumberScreen = 0;
		SceneManager.LoadScene("_GameLevels");
    }

    static public WeaponDefinition GetWeaponDefinition(WeaponType wt)
    {
        if (WEAP_DICT.ContainsKey(wt))
        {
            return (WEAP_DICT[wt]);
        }
        return (new WeaponDefinition());

    }
}