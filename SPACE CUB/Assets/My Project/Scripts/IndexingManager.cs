using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IndexingManager : MonoBehaviour
{
    #region Private Fields
    List<int> priorities;
    int priorityIndex;

    int currentButtonIndex;

    PriorityManager[] cubes;
    #endregion

    private void Start()
    {
        InitializeProperties();
        SortPriorities();
        SetPressedColors();
    }
    void InitializeProperties()
    {
        priorities = new List<int>();
    }

    private void SortPriorities()
    {
        cubes = GetComponentsInChildren<PriorityManager>();
        
        for(int i = 0; i<cubes.Length; i++)
        {
            if (!priorities.Contains(cubes[i].priority))
            {
                if (cubes[i].ifMoveable)
                {
                    priorities.Add(cubes[i].priority);
                }
            }
        }
        Debug.Log(priorities.Count);
        priorities.Sort();
    }

    private void SetPressedColors()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (priorities.Count != 0)
            {
                if (cubes[i].priority == priorities[0] && cubes[i].ifMoveable)
                {
                    cubes[i].SetPressedColor(new Color(0, 255, 0));
                    Debug.Log("Color green for " + cubes[i].gameObject.name);
                }
                else
                {
                    cubes[i].SetPressedColor(new Color(255, 0, 0));
                }
            }
        }
    }
    public void PressedIndex(int i, int index)
    {
        if(priorities.Count != 0)
        {
            if (priorities[0] == i)
            {
                Debug.Log("Green");

                priorities.RemoveAt(0);
                priorities.Sort();
                Debug.Log("Count:: " + priorities.Count);
                
                SetPressedColors();
                Debug.Log("Index is: " + index);
                MakeLastChild(index);
            }
            else
            {
                Debug.Log("Red");
            }
        }
        else
        {
            Debug.Log("List is empty. Game Finish");
            FindObjectOfType<MovementHandler>().GameEndSequence();
        }
    }
    private void MakeLastChild(int index)
    {
        Debug.Log("Making the last sibling");
        currentButtonIndex = index;
        transform.GetChild(index).SetAsLastSibling();
        Debug.Log("Making the last sibling done");
    }
}
