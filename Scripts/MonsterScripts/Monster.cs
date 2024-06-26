using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public event Action<int> HandleDamageEvent;
    public event Action<float, MonsterType, int> AttackEvent;
    public event Action DieEvent;

    public void HitEvent(int damage)
    {
        HandleDamageEvent?.Invoke(damage);
    }

    public void Attack(float damage, MonsterType type, int score)
    {
        AttackEvent?.Invoke(damage, type, score);
    }

    public void CallDieEvent()
    {
        DieEvent?.Invoke();
    }

    public void Release()
    {
        gameObject.SetActive(false);
        gameObject.transform.parent = SpawnManager.instance.transform;
    }
}
