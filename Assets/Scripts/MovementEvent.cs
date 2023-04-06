using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEvent : MonoBehaviour
{
    public event Action<MovementEvent, MovementEventArgs> OnMovement;

    public void CallMovementEvent(Vector3 moveDirection, float moveSpeed)
    {
        Debug.Log("CallMovementEvent" + moveDirection);

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