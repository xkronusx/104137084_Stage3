using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // AppleTree speed
    public float speed = 1f;
    // Distance before AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance for AppleTree to turn around
    public float chanceToChangeDirections = 0.1f;
    // Apple drop rate
    public float secondsBetweenAppleDrops = 1f    ;
    void Start () {
        Invoke("DropApple",2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
        
    }

	void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//Move right
        }
        else if(pos.x > leftAndRightEdge) 
        {
            speed = -Mathf.Abs(speed);//Move left
        }
    }
    void FixedUpdate()
    {
        // Changing Direction Randomly is now time-based because of FixedUpdate()
    if(Random.value < chanceToChangeDirections)
        {
            speed *= -1;// Change direction
        }
    }
}
