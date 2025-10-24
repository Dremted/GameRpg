using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class ManagerInventory : MonoBehaviour
{
    public SlotInventory[] itemSlots;
    public int gold;
    public TMP_Text textGold;
    public UseItem useItem;

    private void Start()
    {
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
    }

    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }
    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }

    public void AddItem(ItemSO itemSO, int quantity)
    {
        if(itemSO.isGold)
        {
            gold += quantity;
            textGold.text = gold.ToString();
            return;
        }

        foreach (var slot in itemSlots)
        {
            if(slot.itemSO == itemSO && slot.quantity < itemSO.stackSize)
            {
                int availableSpace = itemSO.stackSize - slot.quantity;
                int amountToAdd = Mathf.Min(availableSpace, quantity);

                slot.quantity = amountToAdd;
                quantity -= amountToAdd;
            }
        }

            foreach (var slot in itemSlots)
            {
                if (slot.itemSO == null)
                {
                    slot.itemSO = itemSO;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;
                }
            }
            
    }

    public void UseItem(SlotInventory slot)
    {
        if (slot.itemSO != null && slot.quantity >= 0)
        {
            useItem.ApplyItemEffect(slot.itemSO);

            slot.quantity--;
            if(slot.quantity <= 0)
            {
                slot.itemSO = null;
            }
            slot.UpdateUI();
        }
    }
}
