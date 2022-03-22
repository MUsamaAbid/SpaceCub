using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriorityManager : MonoBehaviour
{
    IndexingManager indexingManager;

    public int priority;
    public bool ifMoveable;

    public void OnCubePressed()
    {
        if (!indexingManager) indexingManager = GetComponentInParent<IndexingManager>();
        if (!indexingManager) Debug.LogError("Could not find the indexing manager");

        indexingManager.PressedIndex(priority, transform.GetSiblingIndex());
    }
    public void SetPressedColor(Color color)
    {
        Button btn = GetComponent<Button>();
        ColorBlock colorBlock = btn.colors;

        colorBlock.highlightedColor = btn.colors.highlightedColor;
        colorBlock.normalColor = btn.colors.normalColor;
        colorBlock.selectedColor = btn.colors.selectedColor;
        colorBlock.disabledColor = btn.colors.disabledColor;

        colorBlock.pressedColor = color;

        btn.colors = colorBlock;
    }
}
