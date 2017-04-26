﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour {

    [SerializeField]
    private float speed;
    private Rigidbody rb;
    private State currentState = State.Idle;
    private float jumpHeight = 10.0f;
    private float jumpSpeed;
    private bool isGrounded;
    private PlayerAnim anim;


    private void Start()
    {
        speed = 10.0f;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnim>();
        
       
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Move()
    {
        if (InputManager.Instance.Movement() != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(InputManager.Instance.Movement());
            rb.position += InputManager.Instance.Movement() * speed * Time.deltaTime;
            anim.WalkAnimation(true);
        }
        else
        {
            anim.WalkAnimation(false);
        }
            
    }

    private void Jump()
    {
        jumpSpeed = 5.0f;
        Vector3 height = new Vector3(0,jumpHeight, 0);
        if (InputManager.Instance.GrabButtonDown() && isGrounded)
            rb.velocity = height;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}

public enum State
{
    Idle,
    Walking,
    Attacking,
    Defending,
    Grab
};
