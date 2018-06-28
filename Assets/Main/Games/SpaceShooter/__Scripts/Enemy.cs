using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; //Speed in m/s
    public float firerate = 0.3f; // seconds/ shot
    public float health = 10;
    public int score = 100; // points earned for destroying 
    public float showDamageDuration = 0.1f; //show damage
    public float powerUpDropChance = 1f; // chance to drop power up
    public static int newnum = Main.enemyNumberScreen;
    [Header("Set Dynamically: Enemy")]
    public Color[] originalColors;
    public Material[] materials;// All the Materials of this & its children
    public bool showingDamage = false;
    public float damageDoneTime; // Time to stop showing damage
    public bool notifiedOfDestruction = false; // Will be used later

    protected BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        // Get materials and colors for this gameobject
        materials = Utils.GetAllMaterials(gameObject);
        originalColors = new Color[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
			originalColors [i] = materials [i].color;

        }
    }

    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();

        if (showingDamage && Time.time > damageDoneTime)
        {
            UnShowDamage();
        }

        if (bndCheck != null && bndCheck.offDown)
        {
            // destroy at bottom
            Destroy(gameObject);

            //COME BACK TO THIS
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        switch (otherGO.tag)
        {
            case "ProjectilePlayer":
                Projectile p = otherGO.GetComponent<Projectile>();
                if (!bndCheck.isOnScreen)
                {
                    Destroy(otherGO);
                    break;
                }
                // Hurt this enemy
                ShowDamage();
                //Get the damage amount from the main wep dic
                health -= Main.GetWeaponDefinition(p.type).damageOnHit;
                if (health <= 0)
                {
					MainScreenText.currentScore += score;
					MainScreenText.totalScore   += score;
                    newnum--;
                    Main.enemyNumberScreen = newnum;
                    if (!notifiedOfDestruction)
                    {
                        Main.S.shipDestroyed(this);
                    }
                    notifiedOfDestruction = true;
                    //Destroy this enemy
                    Destroy(this.gameObject);
                }
                Destroy(otherGO);
                break;
            default:
                print("Enemy hit by non-ProjectilePlayer: " + otherGO.name);
                break;
        }

    }

    void ShowDamage()
    {
        foreach (Material m in materials)
        {
            m.color = Color.red;
        }
        showingDamage = true;
        damageDoneTime = Time.time + showDamageDuration;
    }
    void UnShowDamage()
    {
        for (int i = 0; i < materials.Length; i++)
        {
			//materials [i].color = Color.black;
            materials[i].color = originalColors[i];
			/*if (GameManager.enemy0dropValueScorec == "red") {
				originalColors [i] = Color.red;
				materials[i].color = Color.red;
			}

			if (GameManager.enemy0dropValueScorec == "black") {
				originalColors [i] = Color.black;
				materials[i].color = Color.black;
			}

			if (GameManager.enemy0dropValueScorec == "blue") {
				originalColors [i] = Color.blue;
				materials[i].color = Color.blue;
			}*/
        }
        showingDamage = false;
    }

}