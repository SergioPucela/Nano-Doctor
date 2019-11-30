using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPrincipal : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool shooting = false;

    public Animator animator;

    void Update()
    {
        animator.SetBool("isShootingNormal", shooting);
    }

    public IEnumerator ShootWeapon()
    {
        shooting = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(0.2f);
        shooting = false;
    }
    
}
