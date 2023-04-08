using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpEvent : MonoBehaviour
{
    public event Action<JumpEvent> OnJump;

    public void CallJumpEvent()
    {
        OnJump?.Invoke(this);
    }
}
