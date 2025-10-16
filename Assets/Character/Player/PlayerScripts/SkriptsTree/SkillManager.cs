using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Player_Combat player_Combat;
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent; 
    }
    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }

    private void HandleAbilityPointSpent(SkillSlot skillSlot)
    {
        string slotName = skillSlot.skillSO.name;

        switch (slotName)
        {
            case "MaxHealthBoost":
                ManagerStatsPlayer.Instance.AddMaxHealth(1);
                break;

            case "CombatActive":
                player_Combat.enabled = true;
                break;
            default:
                Debug.LogWarning("No that skill" + slotName);
                break;
        }
    }
}
