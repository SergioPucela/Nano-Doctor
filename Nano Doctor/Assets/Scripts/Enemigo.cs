using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int health;
    public int enemyDamage;
    public bool isDead = false;
    public BoxCollider2D colliderCabeza;
    public BoxCollider2D colliderPies;
    public CircleCollider2D colliderCuerpo;

    public Animator animator;

    public Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        animator.SetTrigger("enemyIsDead");
        Destroy(rb2D);
        Destroy(colliderCabeza);
        Destroy(colliderPies);
        Destroy(colliderCuerpo);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().RecibirDaño(enemyDamage);
            StartCoroutine(Die());
        }
    }
}
