using UnityEngine;

public class CharacterHorizontalMovement : MonoBehaviour
{
    [SerializeField] private MovementEvent movementEvent;
    public Vector3 HorizontalMovement { get; private set; }

    void OnEnable()
    {
        if (movementEvent != null)
        {
            movementEvent.OnMovement += HandleMovement;
        }
    }

    void OnDisable()
    {
        if (movementEvent != null)
        {
            movementEvent.OnMovement -= HandleMovement;
        }
    }

    private void HandleMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        Move(new MovementEventArgs
        {
            moveDirection = args.moveDirection,
            moveSpeed = args.moveSpeed
        });
    }

    private void Move(MovementEventArgs args)
    {
        Vector3 move = args.moveDirection * args.moveSpeed;
        Vector3 moveRotatedWithCamera = Quaternion.Euler(0, -45f, 0) * move;
        HorizontalMovement = moveRotatedWithCamera;
    }
}
