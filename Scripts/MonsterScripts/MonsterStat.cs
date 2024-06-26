using System;
using TMPro;
using UnityEngine;

public enum MonsterType
{
    Beholder,
    Cactus,
    Chest,
    MushroomSmile,
    MushroomAngry,
    Slime,
    Swarm08,
    Swarm09,
    Turtle,
    Boss
}

[Serializable]
public class MonsterInfo
{
    [field:SerializeField] public MonsterType Type { get; set; }
    [field:SerializeField] public int HpRate { get; set; }
}

public class MonsterStat : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    [field:SerializeField] public MonsterInfo monsterInfo { get; set; }
    
    [field: SerializeField] public int HP;
    [field: SerializeField] public float AttackRange;
    [field: SerializeField] public LayerMask targetLayer;
    [SerializeField] private TMP_Text HPText;

    [field: SerializeField] public int scoreHp;

    private void Start()
    {
        _monster.HandleDamageEvent += HandleDamage;
    }

    public void InitHp(int value)
    {
        HP = (int)(value * (monsterInfo.HpRate / 10f));
        scoreHp = HP;
        HPText.text = HP.ToString();
    }
    
    private void HandleDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            _monster.CallDieEvent();
            GameManager.instance.KillMonster(monsterInfo.Type, scoreHp);
        }

        HPText.text = HP.ToString();
    }
}
