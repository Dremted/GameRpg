using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevation_Enter : MonoBehaviour
{
    public Collider2D[] mountainCollider;
    public Collider2D[] boundaryCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in mountainCollider)
            {
                mountain.enabled = false;
            }

            foreach (Collider2D boundry in boundaryCollider)
            {
                boundry.enabled = true;
            }
        }
        collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }

}

