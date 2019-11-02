using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public bool faceRight = true;
    private float moveInput;

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
        moveInput = Input.GetAxis("Horizontal");
        canJump = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (faceRight == false && moveInput < 0)
            Flip();
        else if (faceRight == true && moveInput > 0)
            Flip();
    }

    void Update()
    {
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
    }

    public void Move(bool right)
    {
        if (right)
            rb2D.velocity = new Vector2(speed * Time.fixedDeltaTime, rb2D.velocity.y);
        else
            rb2D.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb2D.velocity.y);
    }

    public void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Jump()
    {
        rb2D.velocity = Vector2.up * jumpForce;
    }
}
