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
    [SerializeField] float jumpForce = 0.14f;

    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (moveDirection != Vector3.zero)
        {
            player.movementEvent.CallMovementEvent(moveDirection, moveSpeed);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>().normalized;
        moveDirection = new Vector3(input.x, 0, input.y);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.jumpEvent.CallJumpEvent(jumpForce);
        }
    }
}