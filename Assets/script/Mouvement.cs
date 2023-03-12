using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float moveSpeed;

    public float jumpForce;

    public bool isJumping;

    public bool isGrounded;
    
    public Rigidbody2D var;
    
    private Vector3 velocity = Vector3.zero;

    public Transform groundedLeft;
    public Transform groundedRight;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundedLeft.position, groundedRight.position);
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;


        MovePlayer(horizontalMovement);
        
        Flip(var.velocity.x);

        float characterVelocity = Mathf.Abs(var.velocity.x);
        animator.SetFloat("Speed",characterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, var.velocity.y);
        var.velocity = Vector3.SmoothDamp(var.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            var.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
        
        
    }

    void Flip(float velo)
    {
        if (velo < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    
}
