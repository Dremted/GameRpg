using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_bow : MonoBehaviour
{
    public Transform posBow;
    public GameObject prefabArrow;
    public PlayerMovement player;

    public void Shoot(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            Arrow arrow = Instantiate(prefabArrow, posBow.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = player.moveInput;
        }

    }

}
