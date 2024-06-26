using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ObjectPool ObjectPool { get; private set; }
    public PlayerStat PlayerStat { get; private set; }
    public Player Player { get; private set; }
    public bool upgrade;
    public TextMeshProUGUI scoreTxt;

    public int score;
    public TextMeshProUGUI bestScoreTxt;
    public int deadMonster;

    public int EnemyHP = 10;    // 몬스터 체력

    public int SpawnMonsterCount = 0; // 몬스터 스폰 개수

    public event Action UpgradeEvent;
    public event Action SpawnMonsterEvent;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        ObjectPool = GetComponent<ObjectPool>();
        PlayerStat = GetComponent<PlayerStat>();
        Player = GetComponent<Player>();

        PlayerStat.Init();
        InitGame();
    }

    public void KillMonster(MonsterType type, int scoreHp)
    {
        ++deadMonster;
        
        score += scoreHp; // Todo : 몬스터 잡았을 때 점수 얼마나 줄건지

        if (type == MonsterType.Boss)
        {
            UpgradeEvent?.Invoke();
        }

        scoreTxt.text = score.ToString();

        if (deadMonster % 5 == 0)
        {
            UpgradeEvent?.Invoke();
        }
    }

    public void MonsterUpgrade()
    {
        SpawnMonsterCount++;

        SpawnMonsterEvent?.Invoke();

        EnemyHP += UnityEngine.Random.Range(1, Mathf.FloorToInt(EnemyHP*0.3f));
    }

    public void InitGame()
    {
        bestScoreTxt.text = DataManager.Instance.bestScore.ToString();
        DataManager.Instance.InitData();
    }
}