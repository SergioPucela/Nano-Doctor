using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 50f;
    public Rigidbody2D rb;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Physics2D.IgnoreLayerCollision(10, 11);
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        Enemigo enemigo = collisionInfo.GetComponent<Enemigo>();
        if(enemigo != null)
        {
            enemigo.TakeDamage(damage);
        }
        Debug.Log(collisionInfo.name);
        Destroy(gameObject);
    }
}
