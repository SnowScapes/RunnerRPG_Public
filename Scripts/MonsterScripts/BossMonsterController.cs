using System.Collections;
using UnityEngine;

public class BossMonsterController : MonsterController
{
    protected override IEnumerator AttackRay()
    {
        while (!die)
        {
            for (int i = -2; i < 3; i++)
            {
                Vector3 rayPos = new Vector3(transform.position.x + (1.5f * i), RayHeight.y, transform.position.z);
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
