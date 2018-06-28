﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspectior")]

    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamically")]

    public int levelShown = 0;

    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        //Get current shield level from player
        int currLevel = Mathf.FloorToInt(Player.S.shieldLevel);
        //If different than levelShown
        if (levelShown != currLevel)
        {
            levelShown = currLevel;
            //Change texture to show different level
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }
        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}