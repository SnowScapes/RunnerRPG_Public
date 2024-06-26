using UnityEngine;

public class Sensor : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.MonsterUpgrade();
            SpawnManager.instance.SpawnEnemy();
        }
    }
}
