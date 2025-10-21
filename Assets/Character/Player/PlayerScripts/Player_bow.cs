using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_bow : MonoBehaviour
{
    public Transform posBow;
    public GameObject prefabArrow;
    public PlayerMovement player;

    public float timerFire = 1f;

    private void Update()
    {
        timerFire -= Time.deltaTime;
    }

    public void Shoot(InputAction.CallbackContext callback)
    {
        if (callback.performed && timerFire <= 0)
        {

            Arrow arrow = Instantiate(prefabArrow, posBow.position, Quaternion.identity).GetComponent<Arrow>();
            if (player.moveInput.x != 0 || player.moveInput.y != 0)
            {
                arrow.direction = player.moveInput;
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
        }
    }

}
