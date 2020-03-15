using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D rgbd2;

    void Start()
    {
        rgbd2 = GetComponent<Rigidbody2D>();
        rgbd2.velocity = new Vector2(GameController.instance.ScrollingSpeed,0);
    }

    
    void Update()
    {
        if(GameController.instance.IsBirdDead == true)
        {
            rgbd2.velocity = Vector2.zero;
        }
    }
}
