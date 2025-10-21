using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_bow : MonoBehaviour
{
    public Transform posBow;
    public GameObject prefabArrow;
    public PlayerMovement player;

    public Animator animator;

    public float timerFire = 1f;

    private void Update()
    {
        timerFire -= Time.deltaTime;
    }

    private void OnEnable()
    {
        animator.SetLayerWeight(0, 0);
        animator.SetLayerWeight(1, 1);
    }

    private void OnDisable()
    {
        animator.SetLayerWeight(0, 1);
        animator.SetLayerWeight(1, 0);
    }

    public void Shoot(InputAction.CallbackContext callback)
    {
        if (callback.performed && timerFire <= 0)
        {
            animator.SetBool("isShooting", true);

            Arrow arrow = Instantiate(prefabArrow, posBow.position, Quaternion.identity).GetComponent<Arrow>();
            if (player.moveInput.x != 0 || player.moveInput.y != 0)
            {
                arrow.direction = player.moveInput;
                animator.SetFloat("aimX", player.moveInput.x);
                animator.SetFloat("aimY", player.moveInput.y);
            }
            else
            {
                if (player.transform.localScale.x == 1)
                {
                    arrow.direction.x = 1;
                }
                else if (player.transform.localScale.x == -1)
                {
                    arrow.direction.x = -1;
                }
            }
            timerFire = 1f;
            animator.SetBool("isShooting", false);
        }
    }

}
