using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public void ApplyItemEffect(ItemSO itemSO)
    {
        if (itemSO.currentHealth > 0)
        {
            ManagerStatsPlayer.Instance.AddHealth(itemSO.currentHealth);
        }

        if(itemSO.maxHealth > 0)
        {
            ManagerStatsPlayer.Instance.AddMaxHealth(itemSO.maxHealth);
        }

        if (itemSO.speed > 0)
        {
            ManagerStatsPlayer.Instance.AddSpeed(itemSO.speed);
        }

        if(itemSO.duration > 0)
        {
            StartCoroutine(EffectTimer(itemSO, itemSO.duration));
        }
    }

    private IEnumerator EffectTimer(ItemSO itemSO, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (itemSO.currentHealth > 0)
        {
            ManagerStatsPlayer.Instance.AddHealth(-itemSO.currentHealth);
        }

        if (itemSO.maxHealth > 0)
        {
            ManagerStatsPlayer.Instance.AddMaxHealth(-itemSO.maxHealth);
        }

        if (itemSO.speed > 0)
        {
            ManagerStatsPlayer.Instance.AddSpeed(-itemSO.speed);
        }

    }
}
