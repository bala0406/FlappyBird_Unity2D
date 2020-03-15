using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackground : MonoBehaviour
{
    public BoxCollider2D groundCollider;
    private float HorizontalGroundLength;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        HorizontalGroundLength = groundCollider.size.x;
    }


    void Update()
    {
        if(transform.position.x < -HorizontalGroundLength)
        {
            RepeatBackground();
        }
    }

    private void RepeatBackground()
    {
        Vector2 GroundOffset = new Vector2(HorizontalGroundLength*2f,0);
        transform.position =(Vector2)transform.position + GroundOffset;
    }
}
