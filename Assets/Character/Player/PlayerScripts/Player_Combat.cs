using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    Animator animator;
    public Transform pointAttack;
    public LayerMask enemyLayer;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ManagerStatsPlayer.Instance.timer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (ManagerStatsPlayer.Instance.timer <= 0)
        {
            animator.SetBool("isAttacking", true);

            ManagerStatsPlayer.Instance.timer = ManagerStatsPlayer.Instance.coldown;
        }
        
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(pointAttack.position, ManagerStatsPlayer.Instance.weaponRadius, enemyLayer);
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-ManagerStatsPlayer.Instance.damage);
            enemies[0].GetComponent<Enemy_Knockback>().Knockback
                (
                transform, ManagerStatsPlayer.Instance.forceKnockback,
                ManagerStatsPlayer.Instance.knockbackTime, 
                ManagerStatsPlayer.Instance.timeStun
                );
        }
    }

    public void AttackComplete()
    {
        animator.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointAttack.position, ManagerStatsPlayer.Instance.weaponRadius);
    }
}
