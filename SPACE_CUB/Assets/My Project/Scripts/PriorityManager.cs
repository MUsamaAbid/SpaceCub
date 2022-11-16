using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriorityManager : MonoBehaviour
{
    IndexingManager indexingManager;

    public int priority;
    public bool ifMoveable;

    public int index;

    public Color color;

    public GameObject[] Above;
    public GameObject[] Below;

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
    public bool Sequence()
    {
        for (int i = 0; i < Above.Length; i++)
        {
            if(transform.GetSiblingIndex() > Above[i].transform.GetSiblingIndex())
            {
                Debug.Log(gameObject.name + "-above-" + Above[i].gameObject.gameObject);
                return false;
            }
        }
        for (int i = 0; i < Below.Length; i++)
        {
            if (transform.GetSiblingIndex() < Below[i].transform.GetSiblingIndex())
            {
                Debug.Log(gameObject.name + "-Bellow-" + Below[i].gameObject.gameObject);
                Debug.Log(transform.GetSiblingIndex() + "-Bellow-" + Below[i].transform.GetSiblingIndex());
                return false;
            }
        }
        return true;
    }
}
