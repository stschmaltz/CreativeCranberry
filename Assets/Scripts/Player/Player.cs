using System;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(JumpEvent))]
[RequireComponent(typeof(CharacterMovementHandler))]
[RequireComponent(typeof(CharacterHorizontalMovement))]
[RequireComponent(typeof(CharacterVerticalMovement))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AttackEvent))]
[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public MovementEvent movementEvent;
    [HideInInspector] public JumpEvent jumpEvent;
    [HideInInspector] public CharacterMovementHandler playerMovementHandler;
    [HideInInspector] public CharacterController characterController;
    [HideInInspector] public CharacterHorizontalMovement playerHorizontalMovement;
    [HideInInspector] public CharacterVerticalMovement playerVerticalMovement;
    [HideInInspector] public AttackEvent attackEvent;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        playerControl = GetComponent<PlayerControl>();
        playerHorizontalMovement = GetComponent<CharacterHorizontalMovement>();
        playerVerticalMovement = GetComponent<CharacterVerticalMovement>();
        playerMovementHandler = GetComponent<CharacterMovementHandler>();
        movementEvent = GetComponent<MovementEvent>();
        jumpEvent = GetComponent<JumpEvent>();
        characterController = GetComponent<CharacterController>();
        attackEvent = GetComponent<AttackEvent>();
    }
}