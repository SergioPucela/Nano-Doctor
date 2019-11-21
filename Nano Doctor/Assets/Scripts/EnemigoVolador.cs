using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador : Enemigo
{

    public GameObject enemy;
    public GameObject player;
    public EnemyAI AI;
    public float enemyView;

    // Start is called before the first frame update
    void Start()
    {
        AI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(enemy.transform.position, player.transform.position) <= enemyView)
            AI.enabled = true;
        else if (Vector2.Distance(enemy.transform.position, player.transform.position) > enemyView)
            AI.enabled = false;
    }
}
