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
    [SerializeField]private ManagerInventory inventoryManager;

    private static ShopManager activeShop;

    private void Start()
    {
        inventoryManager = GetComponentInParent<ManagerInventory>();
    }

    private void OnEnable()
    {
        ShopManager.OnShopStateChange += HandleShopStateChanged;
    }
    private void OnDisable()
    {
        ShopManager.OnShopStateChange -= HandleShopStateChanged;
    }

    public void HandleShopStateChanged(ShopManager shopManager, bool isOpen)
    {
        activeShop = isOpen ? shopManager : null;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (quantity > 0)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (activeShop != null)
                {
                    activeShop.SellItem(itemSO);
                    quantity--;
                    UpdateUI();
                }
                else
                {
                    if (itemSO.currentHealth > 0 && ManagerStatsPlayer.Instance.currentHealth >= ManagerStatsPlayer.Instance.maxHealth)
                        return;

                    inventoryManager.UseItem(this);
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                inventoryManager.DropItem(this);
            }

        }
    }

    public void UpdateUI()
    {
        if(quantity <= 0)
            itemSO = null;

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
