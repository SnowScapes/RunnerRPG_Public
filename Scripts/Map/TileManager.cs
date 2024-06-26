using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;

    public GameObject[] tilePrefabs;
    public Dictionary<int, Queue<GameObject>> TilePool;

    public float tileLength = 40f; // 타일 길이
    public int numberOfTiles = 4; // 시작 시 타일 개수
    int numberOfObj = 5; // 오브젝트 풀 안의 타일 개수
    public float speed = 20f;

    public GameObject CurTile;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        TilePool = new Dictionary<int, Queue<GameObject>>();
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < tilePrefabs.Length; i++)
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            for (int j = 0; j < numberOfObj; j++)
            {
                GameObject go = Instantiate(tilePrefabs[i], transform);
                go.SetActive(false);
                queue.Enqueue(go);
            }

            int key = tilePrefabs[i].GetComponent<Tile>().TileId;
            TilePool.Add(key, queue);
        }
    }

    public GameObject Get(int id)
    {
        return TilePool[id].Dequeue();
    }

    public void Release(int id, GameObject go)
    {
        TilePool[id].Enqueue(go);
    }


    void Start()
    {
        if (GameManager.instance != null)
            GameManager.instance.Player.DieEvent += StopTile;

        for (int i = 0; i < numberOfTiles; i++)
        {
            int idx = Random.Range(0, tilePrefabs.Length);
            GameObject go = Get(idx);
            go.transform.position = transform.forward * (i * tileLength);

            go.SetActive(true);
        }
    }

    public void SpawnTile()
    {
        int idx = Random.Range(0, tilePrefabs.Length);

        CurTile = Get(idx);
        CurTile.transform.position = transform.forward * (tileLength * (numberOfTiles - 1));

        CurTile.SetActive(true);
    }

    public void StopTile()
    {
        speed = 0f;
    }
}