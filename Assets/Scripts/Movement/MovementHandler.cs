using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(JumpEvent))]
[DisallowMultipleComponent]
public class MovementHandler : MonoBehaviour
{
    private CharacterController characterController;
    private Player player;
    private float verticalVelocity;
    public float gravity = -1f;

    private void Awake()
    {
        player = GetComponent<Player>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        // if grounded no need to apply gravity
        verticalVelocity = characterController.isGrounded ? 0 : verticalVelocity + gravity * Time.deltaTime;
        Vector3 gravityVector = new Vector3(0, verticalVelocity, 0);

        MoveObject(gravityVector);
    }

    private void OnEnable()
    {
        player.movementEvent.OnMovement += MovementEvent_HandleOnMovement;
        player.jumpEvent.OnJump += JumpEvent_HandleOnJump;
    }

    private void OnDisable()
    {
        player.movementEvent.OnMovement -= MovementEvent_HandleOnMovement;
        player.jumpEvent.OnJump -= JumpEvent_HandleOnJump;
    }

    private void MovementEvent_HandleOnMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        Vector3 move = args.moveDirection * args.moveSpeed * Time.deltaTime;
        MoveObject(move);
    }

    private void JumpEvent_HandleOnJump(JumpEvent jumpEvent, JumpEventArgs args)

    {
        if (characterController.isGrounded)
        {
            verticalVelocity = args.jumpForce;
            Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);
            MoveObject(jumpVector);
        }
    }

    private void MoveObject(Vector3 moveDirection)
    {
        characterController.Move(transform.TransformDirection(moveDirection));
    }
}
