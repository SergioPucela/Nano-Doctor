using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int health;
    public int enemyDamage;
    public bool isDead = false;

    public Animator animator;

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
