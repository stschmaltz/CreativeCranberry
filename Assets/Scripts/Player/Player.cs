using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(JumpEvent))]
[RequireComponent(typeof(MovementHandler))]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public MovementEvent movementEvent;
    [HideInInspector] public JumpEvent jumpEvent;
    [HideInInspector] public MovementHandler movementHandler;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        playerControl = GetComponent<PlayerControl>();
        movementHandler = GetComponent<MovementHandler>();
        movementEvent = GetComponent<MovementEvent>();
        jumpEvent = GetComponent<JumpEvent>();
    }
}