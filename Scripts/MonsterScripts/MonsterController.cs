using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] protected MonsterStat _stat;
    [SerializeField] protected Monster _monster;
    [SerializeField] protected Collider _collider;

    protected Vector3 RayHeight = new Vector3(0, 0.3f, 0);
    protected bool die = false;

    protected Coroutine startAttack;

    protected virtual void Start()
    {
        _monster.DieEvent += DieSequence;
        _monster.AttackEvent += GameManager.instance.PlayerStat.Damaged;
    }

    private void OnEnable()
    {
        die = false;
        _collider.enabled = true;
        startAttack = StartCoroutine(AttackRay());
    }

    private void DieSequence()
    {
        _collider.enabled = false;
        die = true;
    }

    protected virtual IEnumerator AttackRay()
    {
        while (!die)
        {
            for (int i = -1; i <= 1; i++)
            {
                Vector3 rayPos = new Vector3(transform.position.x + (1f * i), RayHeight.y, transform.position.z);
                if (Physics.Raycast(rayPos, transform.forward, _stat.AttackRange, _stat.targetLayer, QueryTriggerInteraction.Collide))
                {
                    _monster.Attack(_stat.HP, _stat.monsterInfo.Type, _stat.scoreHp);
                    _collider.enabled = false;
                    StopCoroutine(startAttack);
                    break;
                }
            }
            yield return null;
        }
    }
}
