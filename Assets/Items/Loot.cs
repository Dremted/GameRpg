using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public SpriteRenderer sr;
    public ItemSO itemSO;
    public Animator animator;
    public bool canBePickedUp = true;

    public int quantity;
    public static event Action<ItemSO, int> OnItemLooted;

    private void OnValidate()
    {
        if(itemSO == null)
            return;

        UpdateApperance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && canBePickedUp == true)
        {
            animator.Play("anim_itemGet");
            OnItemLooted?.Invoke(itemSO, quantity);
            Destroy(gameObject, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBePickedUp = true;
        }
    }

    private void UpdateApperance()
    {
        sr.sprite = itemSO.itemSprite;
        this.name = itemSO.name;

    }

    public void Initialize(ItemSO itemSO, int quantity)
    {
        this.itemSO = itemSO;
        this.quantity = quantity;
        canBePickedUp = false;
        UpdateApperance();
    }
}
