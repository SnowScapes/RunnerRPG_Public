using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action HitEvent;
    public event Action DieEvent;

    public void CallHitEvent()
    {
        HitEvent?.Invoke();
    }

    public void CallDieEvent()
    {
        DieEvent?.Invoke();
    }
}
