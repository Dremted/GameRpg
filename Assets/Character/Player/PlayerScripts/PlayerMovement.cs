using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;  //Вектор движения изменяется при нажатии
    private Rigidbody2D rb;
    private Animator animator;
    private bool isKnockeBack;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private bool _IsMove = false; // Флаг для анимации движения

    public bool IsMove
    {
        get => _IsMove;

        set
        {
            _IsMove = value;
            animator.SetBool("isMove", value);
        }
    }
    public void OnMove(InputAction.CallbackContext context) //Метод вызывающийся при нажатии кнопки движения
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate() //Само движение
    {
        if (isKnockeBack == false)
        {
            rb.velocity = moveInput * ManagerStatsPlayer.Instance.speedPlayer;

            IsMove = moveInput != Vector2.zero;

            Direction();
        }
    }

    private void Direction()// Изменения картинки через Scale исходя из направления движения
    {
        if(moveInput.x < 0)
        {
            transform.localScale = new Vector2 (-1, 1);
        }
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    public void KnockeBack(Transform enemy, float force, float stunTime)
    {
        isKnockeBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockeBackCounter(stunTime));
    }

    IEnumerator KnockeBackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        isKnockeBack = false;
    }
}

