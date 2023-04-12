using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class PlayerControl : MonoBehaviour
{
    private Player player;
    [SerializeField] private float moveSpeed = 7f;


    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        if (moveDirection != Vector3.zero)
        {
            player.movementEvent.CallMovementEvent(moveDirection, moveSpeed);
        }
        else
        {
            player.movementEvent.CallMovementEvent(Vector3.zero, 0);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.jumpEvent.CallJumpEvent();
        }
    }
}