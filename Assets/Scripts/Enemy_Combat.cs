using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public float knockbackForce;
    public float stunTime;
    public LayerMask playerLayer;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if(0<hits.Length)
        {
            hits[0].GetComponent<HealthPlayer>().ChangeHeath(-damage);
            hits[0].GetComponent<PlayerMovement>().KnockeBack(transform, knockbackForce, stunTime);
        }
    }
}
