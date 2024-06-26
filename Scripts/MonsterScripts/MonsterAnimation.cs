using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Monster _monster;

    private void Start()
    {
        _monster.HandleDamageEvent += HitAnim;
        _monster.AttackEvent += AttackAnim;
        _monster.DieEvent += DieAnim;
    }

    private void OnEnable()
    {
        _animator.Play(0, -1, 0);
    }

    private void HitAnim(int _)
    {
        _animator.SetTrigger("Damaged");
    }

    private void AttackAnim(float _, MonsterType __, int ___)
    {
        _animator.SetTrigger("Attack");
    }

    private void DieAnim()
    {
        _animator.SetTrigger("Die");
    }
}
