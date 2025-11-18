using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postac : MonoBehaviour
{

    public float moveSpeed = 5;
    public float runSpeed = 10;
    public float jumpForce = 300;
    public float moveInput = 5;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;
    public bool isJump = false;
    public bool DoubleJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundChecker.isGrounded || DoubleJump)
            {
                isJump = true;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded))
        {
            DoubleJump = false;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        spriteRenderer.flipX = rb.velocity.x < 0f;

        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            DoubleJump = !DoubleJump;
            isJump = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }
}