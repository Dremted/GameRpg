using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatsPlayerUI : MonoBehaviour
{
    public GameObject[] StatsSlot;
    public CanvasGroup StatsCanvas;

    bool OpenMenuStats = false;

    private void Start()
    {
        UpdateAllStats();
    }

    public void MenuStats(InputAction.CallbackContext context)
    {
        if (!OpenMenuStats)
        {
            StatsCanvas.alpha = 1;
            UpdateAllStats();
            OpenMenuStats = true;
            Time.timeScale = 0;
        }
        else
        {
            StatsCanvas.alpha = 0;
            UpdateAllStats();
            OpenMenuStats = false;
            Time.timeScale = 1;
        }   

    }

    public void UpdateDamage()
    {
        StatsSlot[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + ManagerStatsPlayer.Instance.damage;
    }

    private void UpdateSpeed()
    {
        StatsSlot[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + ManagerStatsPlayer.Instance.speedPlayer;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }

}
