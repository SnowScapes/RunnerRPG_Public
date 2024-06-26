using System.Collections;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    private PlayerController controller;

    private Coroutine shootCo;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        GameManager.instance.Player.DieEvent += StopShoot;
    }

    private void Start()
    {
        shootCo = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            for (int i = 0; i < (int)GameManager.instance.PlayerStat.statDict[EStat.ProjectileAmount]; i++)
            {
                GameObject obj = GameManager.instance.ObjectPool.SpawnFromPool("Projectile");
                obj.transform.position = controller.transform.position + new Vector3(0, 0, 1); // 캐릭터 보다 조금 앞에서 발사
                yield return new WaitForSeconds(0.1f);
            }
            
            yield return new WaitForSeconds(GameManager.instance.PlayerStat.CalculateDelay()); // 발사 주기
        }
    }

    private void StopShoot()
    {
        StopCoroutine(shootCo);
    }
}
