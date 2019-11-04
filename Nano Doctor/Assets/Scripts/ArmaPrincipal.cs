using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPrincipal : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public void ShootWeapon()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
}
