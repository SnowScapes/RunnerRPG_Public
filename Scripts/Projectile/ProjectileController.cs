using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask target;
    private Rigidbody rb;

    private float projectileTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        projectileTime = GameManager.instance.PlayerStat.statDict[EStat.ProjectileDistance] / GameManager.instance.PlayerStat.statDict[EStat.ProjectileSpeed]; // 투사체 생명주기 설정
    }

    private void Update()
    {
        projectileTime -= Time.deltaTime;

        if(projectileTime <= 0f)
        {
            DestroyProjectile();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * GameManager.instance.PlayerStat.statDict[EStat.ProjectileSpeed];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsLayerMatched(target, other.gameObject.layer))
        {
            other.gameObject.GetComponentInParent<Monster>().HitEvent((int)GameManager.instance.PlayerStat.statDict[EStat.Atk]); // 적 체력 감소
            DestroyProjectile();
        }
    }

    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
