using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerMovement player;
    public ArmaPrincipal armaPrincipal;

    void Update()
    {
        GetInput();
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
        if (Input.GetButtonDown("Jump") && player.canJump)
            player.Jump();
        if (Input.GetButtonDown("Fire1"))
            armaPrincipal.Shoot();
    }
}
