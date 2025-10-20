using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
    Rigidbody2D _rb;
    Enemy_Moving enemy_Moving;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        enemy_Moving = GetComponent<Enemy_Moving>();
    }

    public void Knockback(Transform forceTransform, float forceKnockback, float knockbackTime, float stunTime)
    {
        enemy_Moving.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - forceTransform.position).normalized;
        _rb.velocity = direction * forceKnockback;
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        _rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemy_Moving.ChangeState(EnemyState.Idle);
    }
}
