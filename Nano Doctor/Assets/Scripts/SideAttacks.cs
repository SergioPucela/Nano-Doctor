using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideAttacks : MonoBehaviour
{

    public Transform sideAttack;
    public Transform target;
    public float speed;

    void Start()
    {
        sideAttack = GetComponent<Transform>();
        InvokeRepeating("Attack", 1f, 5f);
    }
    public void Attack()
    {
        sideAttack.position = Vector2.MoveTowards(sideAttack.position, target.position, speed);
    }

}
