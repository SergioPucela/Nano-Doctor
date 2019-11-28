using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int health;

    public GameObject player;
    public float speed;
    public float jumpForce;
    public bool faceRight = true;
    private float moveInput;

    private GameObject trigger;

    private Rigidbody2D rb2D;

    public bool canJump;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Dialog myDialog;

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

        if (myDialog.dialogEnd)
        {
            Destroy(trigger);
            myDialog.dialogEnd = false;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma") && canJump)
            player.transform.parent = collision.gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
            player.transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            trigger = collision.gameObject;
            TextosDialogo myText = collision.gameObject.GetComponent<TextosDialogo>();
            myDialog.sentences = myText.sentences;
            myDialog.DialogStart();
        }

        if (collision.gameObject.CompareTag("NanoTank"))
        {
            TanqueNano nano = collision.GetComponent<TanqueNano>();
            nano.Cargar();
        }

        if (collision.gameObject.CompareTag("SideAttack"))
        {
            health = 0;
        }
    }

    public void RecibirDaño(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Aquí puedo poner el efecto de muerte
        Debug.Log("Has muerto");
    }
}
