using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public SkillSO skillSO;

    public Image skillIcon;

    private void OnValidate()
    {
        if (skillSO != null)
            skillIcon.sprite = skillSO.skillIcon; 
    }
}
