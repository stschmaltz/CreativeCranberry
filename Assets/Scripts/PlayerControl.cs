using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public MovementEvent movementEvent;
    public float moveSpeed = 5f;
    public event System.Action OnJumpInput;

    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        movementEvent = GetComponent<MovementEvent>();
    }

    private void Update()
    {
        if (moveDirection != Vector3.zero)
        {
            movementEvent.CallMovementEvent(moveDirection, moveSpeed);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>().normalized;
        moveDirection = new Vector3(input.x, 0, input.y);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // if (context.performed)
        // {
        //     OnJumpInput?.Invoke();
        // }
    }
}