using System;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public event Action<AttackEvent> OnAttack;

    public void CallAttackEvent()
    {
        OnAttack?.Invoke(this);
    }
}