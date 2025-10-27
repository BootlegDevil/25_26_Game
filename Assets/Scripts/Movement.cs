using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postac : MonoBehaviour
{

    public float moveSpeed = 5;
    public float jumpForce = 300;
    public float moveInput = 5;
    public Rigidbody2D rigibody2;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;
    public bool isJump = false;
    public bool DoubleJump;
    public float speed = 1;
    void Start()
    {
        rigibody2 = GetComponent<Rigidbody2D>();
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
        rigibody2.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rigibody2.velocity.y);
        spriteRenderer.flipX = rigibody2.velocity.x < 0f;

        if (isJump)
        {
            rigibody2.AddForce(Vector2.up * jumpForce);
            DoubleJump = !DoubleJump;
            isJump = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed * 1 * 2;
        }
        else
        {
            moveSpeed = moveSpeed * 1;
        }
    }
}