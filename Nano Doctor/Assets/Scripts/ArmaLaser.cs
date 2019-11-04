﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaLaser : MonoBehaviour
{

    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int damage = 10;

    public IEnumerator ShootLaser()
    {
        RaycastHit2D collisionInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (collisionInfo)
        {
            Debug.Log(collisionInfo.transform.name);
            Enemigo enemigo = collisionInfo.transform.GetComponent<Enemigo>();
            if(enemigo != null)
            {
                enemigo.TakeDamage(damage);
            }

            //Instanciar aquí efectos visuales de impacto del láser

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, collisionInfo.point);
        }
        else //En caso de que el laser no choque con nada, damos la impresión de que sigue hasta el infinito
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        //Renderizar láser
        lineRenderer.enabled = true;
        //Esperar un frame
        yield return new WaitForSeconds(0.02f);
        //Quitar renderizado
        lineRenderer.enabled = false;
    }
}
