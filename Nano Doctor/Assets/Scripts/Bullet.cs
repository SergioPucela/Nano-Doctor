using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 50f;
    public Rigidbody2D rb;
    public int damage = 1;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Physics2D.IgnoreLayerCollision(10, 11);
        Physics2D.IgnoreLayerCollision(10, 12);
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        Enemigo enemigo = collisionInfo.GetComponent<Enemigo>();
        JefeFuego jefeFuego = collisionInfo.GetComponent<JefeFuego>();
        if(enemigo != null)
        {
            enemigo.TakeDamage(damage);
        }
        else if (jefeFuego != null)
        {
            jefeFuego.bossTakeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Debug.Log(collisionInfo.name);
        Destroy(gameObject);
    }
}
