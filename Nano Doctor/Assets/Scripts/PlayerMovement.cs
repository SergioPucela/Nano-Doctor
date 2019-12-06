using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public int health;

    public GameObject player;
    public float speed;
    public float jumpForce;
    public bool faceRight = true;
    private float moveInput;

    private GameObject trigger;
    public Dialog myDialog;
    private bool dialogHasStarted = false;

    private Rigidbody2D rb2D;

    public bool canJump;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Animator animator;
    private bool falling;
    private bool jumping;

    public PlayerInput input;
    public Animator blackScreen;

    public bool thisLevelOne;
    public bool playerIsDead = false;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (dialogHasStarted || playerIsDead)
            moveInput = 0;
        else
            moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("PlayerSpeed", Mathf.Abs(moveInput));

        canJump = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (canJump)
        {
            falling = false;
            jumping = false;
        }
        else if (rb2D.velocity.y < 0 && !canJump)
        {
            falling = true;
            jumping = false;
        }
        else if(rb2D.velocity.y > 0 && !canJump)
        {
            falling = false;
            jumping = true;
        }
        animator.SetBool("isFalling", falling);
        animator.SetBool("isJumping", jumping);


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
            dialogHasStarted = false;
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
            dialogHasStarted = true;
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
            RecibirDaño(3);
        }

        if (collision.gameObject.CompareTag("TriggerNextLevel"))
        {
            StartCoroutine(NextLevel());
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            RecibirDaño(1);
        }
    }

    public void RecibirDaño(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator NextLevel()
    {
        blackScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Bossfight Lvl1");
    }

    IEnumerator Die()
    {
        playerIsDead = true;
        input.enabled = false;
        animator.SetBool("boolDead", playerIsDead);
        animator.SetTrigger("isDead");
        blackScreen.SetTrigger("FadeOut");
        Debug.Log("Has muerto");
        yield return new WaitForSeconds(1f);
        if(thisLevelOne)
            SceneManager.LoadScene("Nivel1");
        else
            SceneManager.LoadScene("Bossfight Lvl1");
    }
}
