using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public ItemSO itemSO;
    public TMP_Text priceSlot;
    public TMP_Text nameSlot;
    public Image spriteSlot;

    [SerializeField] private ShopManager shopManager;
    [SerializeField] private ShopInfo shopInfo;

    public int price;

    public void Initialize(ItemSO newItemSlot, int price)
    {
        itemSO = newItemSlot;
        nameSlot.text = newItemSlot.itemName;
        spriteSlot.sprite = newItemSlot.itemSprite;
        this.price = price;
        priceSlot.text = price.ToString();
    }
    

    public void OnBuyButtonClicked()
    {
        shopManager.TryBuyItem(itemSO, price);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(itemSO != null)
            shopInfo.ShowItemInfo(itemSO);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shopInfo.HideItemInfo();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (itemSO != null)
            shopInfo.FollowMouse();
    }
}
