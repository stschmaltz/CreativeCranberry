using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(JumpEvent))]
[DisallowMultipleComponent]
public class MovementHandler : MonoBehaviour
{
    private Player player;
    private float verticalVelocity;
    public float gravity = -9f;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        // if grounded no need to apply gravity
        if (player.characterController.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity += gravity * 5f * Time.deltaTime;
        }

        Vector3 gravityVector = new Vector3(0, verticalVelocity, 0);
        player.characterController.Move(gravityVector * Time.deltaTime);

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
        Vector3 moveRotatedWithCamera = Quaternion.Euler(0, -45f, 0) * move;
        MoveObject(moveRotatedWithCamera);
    }

    private void JumpEvent_HandleOnJump(JumpEvent jumpEvent, JumpEventArgs args)
    {
        if (player.IsPlayerGrounded())
        {
            verticalVelocity = args.jumpForce;

            Vector3 gravityVector = new Vector3(0, verticalVelocity, 0);

            player.characterController.Move(gravityVector * Time.deltaTime);
        }
    }

    private void MoveObject(Vector3 moveDirection)
    {
        player.characterController.Move(transform.TransformDirection(moveDirection));
    }
}
