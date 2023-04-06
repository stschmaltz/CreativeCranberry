using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(MovementEvent))]
[DisallowMultipleComponent]
public class MovementHandler : MonoBehaviour
{
    private Player player;
    private CharacterController characterController;
    private MovementEvent movementEvent;

    private void Awake()
    {
        player = GetComponent<Player>();
        characterController = GetComponent<CharacterController>();
        movementEvent = GetComponent<MovementEvent>();
    }

    private void OnEnable()
    {
        Debug.Log("MovementHandler OnEnable");
        movementEvent.OnMovement += MovementEvent_HandleOnMovement;
    }

    private void OnDisable()
    {
        Debug.Log("MovementHandler OnDisable");

        movementEvent.OnMovement -= MovementEvent_HandleOnMovement;
    }

    private void MovementEvent_HandleOnMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        Vector3 move = args.moveDirection * args.moveSpeed * Time.deltaTime;

        Debug.Log("MovementHandler MovementEvent_HandleOnMovement" + move);
        MoveObject(move);
    }

    private void MoveObject(Vector3 moveDirection)
    {
        characterController.Move(transform.TransformDirection(moveDirection));

    }
}
