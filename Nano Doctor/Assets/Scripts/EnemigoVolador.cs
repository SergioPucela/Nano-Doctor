using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador : Enemigo
{

    public Transform enemy;
    public GameObject player;
    public EnemyAI AI;
    public float enemyView;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
        AI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            AI.speed = 0f;
            AI.enabled = false;
        }
        if (Vector2.Distance(enemy.position, player.transform.position) <= enemyView)
        {
            AI.speed = 400f;
            AI.enabled = true;
        }
        else if (Vector2.Distance(enemy.position, player.transform.position) > enemyView)
        {
            AI.speed = 0f;
            AI.enabled = false;
        }
    }
}
