﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // variables

    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        bool isOnTheGround = IsOnTheGround();
        animator.SetBool("isGrounded",isOnTheGround);

        if ((Input.GetMouseButtonDown(0)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W))
            && isOnTheGround)
        {    
            Jump();
        }

    }

    //Methods

    void Jump() {
       
            rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        
    }

    bool IsOnTheGround() {
        print("mask=" + groundLayerMask);
        return Physics2D.Raycast(
            this.transform.position,
            Vector2.down,
            1.5f, 
            groundLayerMask.value);
    }
}
