using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(JumpEvent))]
[RequireComponent(typeof(CharacterMovementHandler))]
[RequireComponent(typeof(CharacterHorizontalMovement))]
[RequireComponent(typeof(CharacterVerticalMovement))]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public MovementEvent movementEvent;
    [HideInInspector] public JumpEvent jumpEvent;
    [HideInInspector] public CharacterMovementHandler playerMovementHandler;
    [HideInInspector] public CharacterController characterController;
    [HideInInspector] public CharacterHorizontalMovement playerHorizontalMovement;
    [HideInInspector] public CharacterVerticalMovement playerVerticalMovement;

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
    }
}