using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(JumpEvent))]
[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public MovementEvent movementEvent;
    [HideInInspector] public JumpEvent jumpEvent;
    [HideInInspector] public MovementHandler movementHandler;
    [HideInInspector] public CharacterController characterController;
    [SerializeField] private float groundCheckDistance = 0.1f;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        playerControl = GetComponent<PlayerControl>();
        movementHandler = GetComponent<MovementHandler>();
        movementEvent = GetComponent<MovementEvent>();
        jumpEvent = GetComponent<JumpEvent>();
        characterController = GetComponent<CharacterController>();
    }

    public bool IsPlayerGrounded()
    {
        RaycastHit hit;
        float distance = characterController.height / 2 + groundCheckDistance;
        Vector3 direction = Vector3.down;

        return Physics.Raycast(transform.position, direction, out hit, distance);
    }
}