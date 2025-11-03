using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public Animator animator;
    public LayerMask playerLayer;
    public GameObject button;
    public CanvasGroup panelShop;

    private bool playerInRange;
    private bool shopIsOpen;

    public void OnShopPanel()
    {
        if (playerInRange)
        {
            if (!shopIsOpen)
            {
                Time.timeScale = 0;
                panelShop.alpha = 1;
                panelShop.blocksRaycasts = true;
                panelShop.interactable = true;
                shopIsOpen = true;
            }
            else
            {
                Time.timeScale = 1;
                panelShop.alpha = 0;
                panelShop.blocksRaycasts = false;
                panelShop.interactable = false;
                shopIsOpen = false;
            }
        }
    }

    private void Awake()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((playerLayer.value & 1<< collision.gameObject.layer) > 0)
        {
            button.SetActive(true);    
            animator.SetBool("playerInRange", true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((playerLayer.value & 1 << collision.gameObject.layer) > 0)
        {
            animator.SetBool("playerInRange", false);
            playerInRange = false;
            button.SetActive(false);
        }
    }
}
