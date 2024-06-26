using System.Collections;
using UnityEngine;

public class MonsterRenderer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Monster _monster;

    private WaitForSeconds delay = new WaitForSeconds(0.1f);

    private void Start()
    {
        _monster.HandleDamageEvent += HitEffect;
    }

    private void HitEffect(int _)
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        _renderer.material.color = Color.red;
        yield return delay;
        _renderer.material.color = Color.white;
    }
}
