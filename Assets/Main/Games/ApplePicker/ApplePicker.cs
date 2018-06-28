﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour {
    public GameObject basketPrefab;
    public int numBaskets =3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }
    public void AppleDestroyed()
    {
        // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }
        // Destroy one of the baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count -1;
        // Grab refrerence to Basket
        GameObject tBasketGO = basketList[basketIndex];
        // Remove basket and destroy object
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if(basketList.Count == 0) {
            SceneManager.LoadScene("ApplepickerScene");
        }
    }
        
    void Update () {
		
	}
}