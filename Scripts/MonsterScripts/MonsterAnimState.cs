using UnityEngine;

public class MonsterAnimState : StateMachineBehaviour
{
    private bool first = true;
    private Monster _monster;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (first)
        {
            _monster = animator.GetComponent<Monster>();
            first = false;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monster.Release();
    }
}
