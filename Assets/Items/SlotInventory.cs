using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventory : MonoBehaviour, IPointerClickHandler
{
    public ItemSO itemSO;
    public int quantity;

    public Image itemImage;
    public TMP_Text quantityText;
    ManagerInventory inventoryManager;

    private void Start()
    {
        inventoryManager = GetComponentInParent<ManagerInventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (quantity > 0)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                inventoryManager.UseItem(this);
            }
        }
    }

    public void UpdateUI()
    {
        if (itemSO != null)
        {
            itemImage.sprite = itemSO.itemSprite;
            itemImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }

}
