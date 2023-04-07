using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementEvent : MonoBehaviour
{
    public event Action<MovementEvent, MovementEventArgs> OnMovement;

    public void CallMovementEvent(Vector3 moveDirection, float moveSpeed)
    {

        OnMovement?.Invoke(this, new MovementEventArgs()
        {
            moveDirection = moveDirection,
            moveSpeed = moveSpeed
        });
    }
}


public class MovementEventArgs : EventArgs
{
    public Vector3 moveDirection;
    public float moveSpeed;
}
