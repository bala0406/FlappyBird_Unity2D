using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rgbd2d;
    private Animator animator;

    public TouchPhase TouchPhase { get; private set; }


    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rgbd2d.velocity = Vector2.zero;
                rgbd2d.AddForce(new Vector2(0, upForce));
                animator.SetTrigger("Flap");
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    rgbd2d.velocity = Vector2.zero;
                    rgbd2d.AddForce(new Vector2(0, upForce));
                    animator.SetTrigger("Flap");              // for Mobile
                }
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rgbd2d.velocity = Vector2.zero;
        isDead = true;
        animator.SetTrigger("Die");
        GameController.instance.BirdDied();
    }
}
