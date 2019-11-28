using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFuego : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject proyectil;

    //public GameObject rightAttack;
    //public GameObject leftAttack;


    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0)
        {
            Instantiate(proyectil, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
