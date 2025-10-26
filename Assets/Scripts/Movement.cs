using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1000;
    public float jumpForce = 300;
    private float moveInput = 0;
    public bool isJump = false;
    public float jumpcounter = 2;
    public float speed = 1;

    public Rigidbody2D rb;
    public SpriteRenderer spriterenderer;
    public GroundChecker groundChecker;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJump = true;
        }
    }
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * moveInput * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if (groundChecker.isGrounded)
        {
            jumpcounter = 2;
        }
        if (isJump && jumpcounter > 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isJump = false;
            jumpcounter = jumpcounter - 1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2;
        }
        else
        {
            speed = 1;
        }
    }
}
