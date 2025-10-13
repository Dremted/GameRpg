using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointText;
    public int availablePoints;

    private void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(() => CheckAvailablePoints(slot));
        }
        UpdateAbilityPoints(0);
    }

    private void CheckAvailablePoints(SkillSlot slot)
    {
        if (availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }
    }

    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
    }

    private void HandleAbilityPointSpent(SkillSlot skillSlot)
    {
        if(availablePoints>0)
        {
            UpdateAbilityPoints(-1);
        }
    }

    private void HandleSkillMaxed(SkillSlot skillSlot)
    {
        foreach(SkillSlot slot in skillSlots)
        {
            if(!slot.isUnlocked && slot.CanUnlockSkill())
            slot.Unlock();
        }
    }

    public void UpdateAbilityPoints(int amount)
    {
        availablePoints += amount;
        pointText.text = "Points: " + availablePoints;
    }
}
