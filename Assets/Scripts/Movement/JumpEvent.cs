using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpEvent : MonoBehaviour
{
    public event Action<JumpEvent, JumpEventArgs> OnJump;

    public void CallJumpEvent(float jumpForce)
    {
        OnJump?.Invoke(this, new JumpEventArgs()
        {
            jumpForce = jumpForce
        });
    }
}

public class JumpEventArgs : EventArgs
{
    public float jumpForce;
}