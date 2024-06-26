using System.Collections.Generic;
using UnityEngine;

public enum EStat
{
    Hp,
    Atk,
    ProjectileDistance,
    ProjectileSpeed,
    ProjectileDelay,
    ProjectileAmount,
    Count
}

[System.Serializable]
public class StatInit
{
    public EStat myEnum;
    public float myValue;
}

public class PlayerStat : MonoBehaviour
{
    public Dictionary<EStat, float> statDict { get; set; } = new Dictionary<EStat, float>();
    [SerializeField] private List<StatInit> initialStat;
    public float projectileDelayTime { get; set; } = 1;

    private void Start()
    {
        projectileDelayTime = 1;
    }

    public void Init()
    {
        foreach (var stat in initialStat)
        {
            statDict.TryAdd(stat.myEnum, stat.myValue);
        }
    }

    public void AddStat(EStat target, float value)
    {
        statDict[target] += value;
    }

    public void Damaged(float damage, MonsterType type, int score)
    {
        statDict[EStat.Hp] -= damage;

        if(statDict[EStat.Hp] <= 0f)
        {
            statDict[EStat.Hp] = 0f;
            GameManager.instance.Player.CallDieEvent();
        }
        else
        {
            GameManager.instance.KillMonster(type, score);
            GameManager.instance.Player.CallHitEvent();
        }
    }

    public float CalculateDelay()
    {
        projectileDelayTime -= projectileDelayTime * (statDict[EStat.ProjectileDelay] / 10);
        statDict[EStat.ProjectileDelay] = 0;
        return projectileDelayTime;
    }
}
