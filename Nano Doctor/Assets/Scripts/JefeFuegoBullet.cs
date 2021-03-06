﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFuegoBullet : MonoBehaviour
{

    public float speed;
    public int bossDamage;

    private Transform player;
    private Vector2 target;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            PlayerMovement myPlayer = collisionInfo.GetComponent<PlayerMovement>();
            myPlayer.RecibirDaño(bossDamage);
            Destroy(gameObject);
        }
    }
}
