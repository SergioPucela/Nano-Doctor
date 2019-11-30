using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerMovement player;
    public ArmaPrincipal armaPrincipal;
    public ArmaLaser armaLaser;
    public Animator animator;

    public bool armaEquipada = true;

    void Update()
    {
        GetInput();
        animator.SetBool("changeWeapon", armaEquipada);
    }

    void FixedUpdate()
    {
        GetMovementInput();
    }

    void GetMovementInput()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
            player.Move(true);
        else if (Input.GetAxisRaw("Horizontal") == -1)
            player.Move(false);
    }

    void GetInput()
    {
        if (Input.GetButtonDown("ChangeWeapon"))
            armaEquipada = !armaEquipada;
        if (Input.GetButtonDown("Jump") && player.canJump)
            player.Jump();
        if (Input.GetButtonDown("Fire1"))
        {
            if (armaEquipada)
                StartCoroutine(armaPrincipal.ShootWeapon());
            else
                StartCoroutine(armaLaser.ShootLaser());
        }
    }
}
