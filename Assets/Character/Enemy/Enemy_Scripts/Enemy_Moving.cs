using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Moving : MonoBehaviour
{
    public float speedMove = 4f;
    private EnemyState enemyState;
    public float attackRange = 2f;
    public float attackColldown = 1f;
    public float playerDetectedRange = 5f;
    public Transform detectedPointer;
    public LayerMask playerLayer;

    private float coldownTimerAttack;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]private Transform targetPlayer;
 
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        ChangeState(EnemyState.Idle);
    }

    private void Update()
    {
        if (enemyState == EnemyState.Knockback)
            return;
        CheckForPlayer();
        if (coldownTimerAttack > 0)
        {
            coldownTimerAttack -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (enemyState == EnemyState.Knockback)
            return;
            if (enemyState == EnemyState.Attacking)
                rb.velocity = Vector2.zero;
            else if (enemyState == EnemyState.Chasing)
                Chase();
    }

    private void Chase()
    {
        Direction();
        Vector2 direction = (targetPlayer.position - transform.position).normalized;
        rb.velocity = direction * speedMove;

    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectedPointer.position, playerDetectedRange, playerLayer);

        if(hits.Length > 0)
        {
            targetPlayer = hits[0].transform;

            if (Vector2.Distance(transform.position, targetPlayer.position) <= attackRange && coldownTimerAttack <= 0)
            {
                coldownTimerAttack = attackColldown;
                ChangeState(EnemyState.Attacking);
            }

            else if (Vector2.Distance(transform.position, targetPlayer.position) >= attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    private void Direction()
    {   
        if(targetPlayer == null)
             return; 
        if (targetPlayer.position.x < transform.position.x)
            transform.localScale = new Vector3(-1,1,1);
        else
            transform.localScale = new Vector3(1,1,1);
    }

    public void ChangeState(EnemyState state)
    {

        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", false);
        }


            enemyState = state;


        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectedPointer.position, playerDetectedRange);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockback
}