using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTree : MonoBehaviour
{
    public CanvasGroup canvasTree;
    public bool isActive;


    public void VisualPanekSkill()
    {
        if (!isActive)
        {
            canvasTree.alpha = 1;
            canvasTree.interactable = true;
            canvasTree.blocksRaycasts = false;
            Time.timeScale = 0;
            isActive = true;
        }
        else
        {
            canvasTree.alpha = 0;
            canvasTree.interactable = false;
            canvasTree.blocksRaycasts = false;
            Time.timeScale = 1;
            isActive = false;
        }
    }

}
