using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public ObjectPool objectPool;

    public Transform[] spawnPoint = new Transform[3];

    public List<MonsterPrefab> monsterList;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();

        foreach (var monster in monsterList)
        {
            objectPool.AddObjectPool(monster.tag, monster.prefab, monster.size);
        }
    }


    public void SpawnEnemy()
    {
        if (TileManager.Instance.CurTile == null)
            return;

        if (GameManager.instance.SpawnMonsterCount % 10 == 0)
        {
            if (GameManager.instance.SpawnMonsterCount % 30 == 0)
                SpawnBossLine();
            else
                SpawnThreeLine();
            return;
        }

        string tag = monsterList[Random.Range(0, monsterList.Count-1)].tag; // List의 맨 마지막은 보스

        Transform spawnPos = spawnPoint[Random.Range(0, 3)];

        GameObject obj = objectPool.SpawnFromPool(tag);

        // 체력 세팅
        MonsterStat monsterStat = obj.GetComponent<MonsterStat>();
        if (monsterStat != null)
        {
            monsterStat.InitHp(GameManager.instance.EnemyHP);
        }

        // 위치 잡아주기
        
        obj.transform.position = spawnPos.position;
        obj.transform.parent = TileManager.Instance.CurTile.transform;

    }

    public void SpawnBossLine()
    {
        GameObject obj = objectPool.SpawnFromPool(monsterList[monsterList.Count-1].tag);
        MonsterStat monsterStat = obj.GetComponent<MonsterStat>();
        
        if (monsterStat != null)
        {
            monsterStat.InitHp(GameManager.instance.EnemyHP);
        }

        obj.transform.position = spawnPoint[1].position;
        obj.transform.parent = TileManager.Instance.CurTile.transform;
    }
    
    public void SpawnThreeLine()
    {
        foreach (var spawn in spawnPoint)
        {
            string tag = monsterList[Random.Range(0, monsterList.Count-1)].tag;
            GameObject obj = objectPool.SpawnFromPool(tag);

            MonsterStat monsterStat = obj.GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                monsterStat.InitHp(GameManager.instance.EnemyHP);
            }

            obj.transform.position = spawn.position;
            obj.transform.parent = TileManager.Instance.CurTile.transform;
        
        }
    }
}

[System.Serializable]
public struct MonsterPrefab
{
    public string tag;
    public GameObject prefab;
    public int size;
}