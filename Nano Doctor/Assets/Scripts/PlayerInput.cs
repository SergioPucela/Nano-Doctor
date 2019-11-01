using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerMovement player;

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
    }
}
