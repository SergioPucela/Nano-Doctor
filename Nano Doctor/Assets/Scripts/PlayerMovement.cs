using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody2D rb2D;

    public bool canJump;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update()
    {
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
    }

    public void Move(bool faceRight)
    {
        if (faceRight)
            rb2D.velocity = new Vector2(speed * Time.fixedDeltaTime, rb2D.velocity.y);
        else
            rb2D.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb2D.velocity.y);
    }

    public void Jump()
    {
        rb2D.velocity = Vector2.up * jumpForce;
    }
}
