using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction = Vector2.right;

    public float lifeArrow = 2f;
    public float speed;
    public int damage = 1;

    public LayerMask enemyLayer;

    public float forceKnockback;
    public float timeKnockback;
    public float stun;

    void Start()
    {
        rb.velocity = direction * speed;
        RotateArrow();
        Destroy(gameObject, lifeArrow);
    }

    private void RotateArrow()
    {
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angel));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((enemyLayer.value & (1<< collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<Enemy_Health>().ChangeHealth(-damage);
            collision.gameObject.GetComponent<Enemy_Knockback>().Knockback(transform, forceKnockback, timeKnockback, stun);
        }
    }
}
