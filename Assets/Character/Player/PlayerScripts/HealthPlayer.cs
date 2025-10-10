using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPlayer : MonoBehaviour
{
    public TMP_Text healthText;
    public Animator healthAnim;

    private void Start()
    {
        healthText.text = "HP:" + ManagerStatsPlayer.Instance.currentHealth + " / " + ManagerStatsPlayer.Instance.maxHealth;
    }

    public void ChangeHeath(int amount)
    {
        healthAnim.Play("Health_Text");

        ManagerStatsPlayer.Instance.currentHealth += amount;

        healthText.text = "HP:" + ManagerStatsPlayer.Instance.currentHealth + " / " + ManagerStatsPlayer.Instance.maxHealth;

        if (ManagerStatsPlayer.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
