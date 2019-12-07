using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatrulla : Enemigo
{

    public float speed;
    public float rayDistance = 2f;

    private bool moveRight = true;

    public Transform groundDetection;

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            speed = 0f;

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);

        if(groundInfo.collider == false)
        {
            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                moveRight = true;
            }
        }
    }
}
