using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        GameManager.instance.Player.HitEvent += HitAnim;
        GameManager.instance.Player.DieEvent += DieAnim;
    }

    private void HitAnim()
    {
        _animator.SetTrigger("Hit");
    }

    private void DieAnim()
    {
        _animator.SetBool("IsDead", true);
    }
}
