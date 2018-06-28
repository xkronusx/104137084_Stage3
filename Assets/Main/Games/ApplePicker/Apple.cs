using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    //Float to tell bottom used for apples to know when to be removed
    public static float bottomY = -20f;
    
    void Start () {
		
	}
	
	void Update () {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            // Grap reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent <ApplePicker>();
            // Call public AppleDestroyed() of apScript
            apScript.AppleDestroyed();
        }
    }
}
