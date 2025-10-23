using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public SpriteRenderer sr;
    public ItemSO itemSO;
    public Animator animator;

    public int quantity;
    public static event Action<ItemSO, int> OnItemLooted;

    private void OnValidate()
    {
        if(itemSO == null)
            return;

        sr.sprite = itemSO.itemSprite;
        this.name = itemSO.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            animator.Play("anim_itemGet");
            OnItemLooted?.Invoke(itemSO, quantity);
            Destroy(gameObject, .5f);
        }
    }

}
