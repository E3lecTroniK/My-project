using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingLeft = true;
    float jumpPower = 5f;
    bool isGrounded = false;


    // For double jump
    int jumpCount = 0;
    [SerializeField] int maxJumps = 2;

    // Animator parameters
    // isJumping = true while moving upward
    // isFalling = true while moving downward

    Vector2 startPosition;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();

        // Check if jump key was pressed and we haven't exceeded max jumps
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
            isGrounded = false;
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }

        // Update animator states based on y-velocity
        if (!isGrounded)
        {
            if (rb.velocity.y > 0)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
            }
            else if (rb.velocity.y < 0)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if ((isFacingLeft && horizontalInput < 0f) || (!isFacingLeft && horizontalInput > 0f))
        {
            isFacingLeft = !isFacingLeft;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When player lands on the ground
        isGrounded = true;
        jumpCount = 0;
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
    }

    public void Die()
    {
        transform.position = startPosition;
    }
}