using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaLaser : MonoBehaviour
{

    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int damage = 10;
    public int cargador = 0;
    private bool shooting = false;
    public Animator animator;

    public GameObject laserImpact;

    void Update()
    {
        animator.SetBool("isShootingLaser", shooting);
    }

    public IEnumerator ShootLaser()
    {
        if (cargador >= 1) //Si hay suficientes nanomateriales en el cargador del láser, en este caso he puesto 2 unidades
        {
            cargador -= 1; //El laser pierde esa cantidad de nanomateriales 

            RaycastHit2D collisionInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

            if (collisionInfo)
            {
                if (collisionInfo.transform.tag == "Trigger") //Si hay un trigger, dar la impresión de que lo atraviesa
                {
                    lineRenderer.SetPosition(0, firePoint.position);
                    lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
                }
                else
                {
                    Debug.Log(collisionInfo.transform.name);
                    Enemigo enemigo = collisionInfo.transform.GetComponent<Enemigo>();
                    if (enemigo != null)
                    {
                        enemigo.TakeDamage(damage);
                    }

                    Instantiate(laserImpact, collisionInfo.point, Quaternion.identity);

                    lineRenderer.SetPosition(0, firePoint.position);
                    lineRenderer.SetPosition(1, collisionInfo.point);
                }
            }
            else //En caso de que el laser no choque con nada, damos la impresión de que sigue hasta el infinito
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            }

            //Inicio la animación de disparo láser
            shooting = true;
            //Renderizar láser
            lineRenderer.enabled = true;
            //Esperar un frame
            yield return new WaitForSeconds(0.02f);
            //Desactivo la animación de disparo láser
            shooting = false;
            //Quitar renderizado
            lineRenderer.enabled = false;
        }
        
    }
}
