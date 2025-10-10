using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStatsPlayer : MonoBehaviour
{
    public static ManagerStatsPlayer Instance;

    [Header("Move Stats")]
    public float speedPlayer;

    [Header("Combat Stats")]
    public float forceKnockback;
    public float knockbackTime;

    public float weaponRadius = 1;
    public float timeStun;

    public float coldown;
    public float timer;
    public int damage;

    [Header("Player Health")]
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
