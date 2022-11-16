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
    bool ifLevelFinished;
    #endregion

    private void Start()
    {
        ifLevelFinished = false;

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

        for (int i = 0; i < cubes.Length; i++)
        {
            //Debug.Log("Cube added: " + cubes[i].gameObject.name);
            if (!priorities.Contains(cubes[i].priority))
            {
                if (cubes[i].ifMoveable)
                {
                    priorities.Add(cubes[i].priority);
                }
            }
        }
        //Debug.Log(priorities.Count);
        priorities.Sort();
    }

    public void PressedIndex(int i, int index)
    {
        //if(priorities.Count != 0)
        //{
        //    if (priorities[0] == i)
        //    {
        //        Debug.Log("Green");

        //        priorities.RemoveAt(0);
        //        priorities.Sort();
        //        Debug.Log("Count:: " + priorities.Count);

        //        //SetPressedColors();
        //        Debug.Log("Index is: " + index);
        //        //MakeLastChild(index);
        //    }
        //    else
        //    {
        //        Debug.Log("Red");
        //    }
        //    MakeLastChild(index);
        //    SetPressedColors();
        //}
        //else
        //{
        //    Debug.Log("List is empty. Game Finish");
        //    FindObjectOfType<MovementHandler>().GameEndSequence();
        //}
        //if(index == 0)
        //    CheckForSequence();
        
        if (index == 0)
            CheckForSequence();
      
        MakeLastChild(index);
        SetPressedColors();
    }
    private void SetPressedColors()
    {
        //for (int i = 0; i < cubes.Length; i++)
        //{
        //    if (priorities.Count != 0)
        //    {
        //        if (cubes[i].priority == priorities[0] && cubes[i].ifMoveable)
        //        {
        //            cubes[i].SetPressedColor(new Color(0, 255, 0));
        //            Debug.Log("Color green for " + cubes[i].gameObject.name);
        //        }
        //        else
        //        {
        //            cubes[i].SetPressedColor(new Color(255, 0, 0));
        //        }
        //    }
        //}

        for (int i = 0; i < cubes.Length; i++)
        {
            if (!cubes[i].gameObject.GetComponent<FindLayeredSprites>()) return;
            
            GameObject[] layeredObjects = cubes[i].gameObject.GetComponent<FindLayeredSprites>().OverlappingSprites;
            
            //Debug.Log("Cube: " + cubes[i].gameObject.name);
            
            bool isLast = true;
            
            for (int j = 0; j < layeredObjects.Length; j++)
            {
                //Debug.Log("Child number" + layeredObjects[j].transform.GetSiblingIndex());
                //Debug.Log("Sibling - " + layeredObjects[j].transform.GetSiblingIndex() + " - " + layeredObjects[j].name);
                if (cubes[i].transform.GetSiblingIndex() < layeredObjects[j].transform.GetSiblingIndex())
                {
                    isLast = false;
                }
            }
           
            if (isLast)
            {
                cubes[i].SetPressedColor(new Color(255, 0, 0));
                cubes[i].color = Color.red;
                //Debug.Log("Red: " + cubes[i]);
            }
            else
            {
                cubes[i].SetPressedColor(new Color(0 ,255, 0));
                cubes[i].color = Color.green;
                //Debug.Log("Green: " + cubes[i]);
            }
        }
    }
    private void MakeLastChild(int index)
    {
        currentButtonIndex = index;
        transform.GetChild(index).SetAsLastSibling();
    }
    public void CheckForSequence()
    {
        //Debug.Log("Centre button pressed");

        //bool finished = true;
        //for (int i = 0; i < cubes.Length; i++)
        //{
        //    if(cubes[i].index == 0)
        //    {
        //        if(cubes[i].color != Color.red)
        //        {
        //            finished = false;
        //            Debug.Log(cubes[i].gameObject.name + ":" + cubes[i].color);
        //        }
        //    }
        //    else
        //    {
        //        if (cubes[i].color != Color.green)
        //        {
        //            finished = false;
        //            Debug.Log(cubes[i].gameObject.name + ":" + cubes[i].color);
        //        }
        //    }
        //}
        //if (finished)
        //{
        //    Debug.Log("List is empty. Game Finish");
        //    //FindObjectOfType<MovementHandler>().GameEndSequence();
        //}
        Debug.Log("In indexing manager again- isLevelFinish: " + ifLevelFinished);
        for (int i = 0; i < cubes.Length; i++)
        {
            if (!cubes[i].Sequence())
            {
                Debug.Log("Not in sequence: " + cubes[i].gameObject.name);
                return;
            }
        }
        if (ifLevelFinished)
        {
            FindObjectOfType<GamePlayUI>().StopTimer();

            FindObjectOfType<MovementHandler>().GameEndSequence();
            ifLevelFinished = false;
            Debug.Log("Level Finished");

            UnlockNextLevel();
            UnlockNextGalaxy();
        }
        else
        {
            ifLevelFinished = true;
            Debug.Log("Level Finished is true");

            CalculateStars();

            for (int i = 0; i < cubes.Length; i++)
            {
                if (cubes[i].gameObject.tag == "Centre")
                {
                    cubes[i].SetPressedColor(new Color(255, 255, 255));
                    Debug.Log("Pressed color is neutral");
                }
            }
        }
    }
    void CalculateStars()
    {
        int minClicks = FindObjectOfType<LevelHandler>().MinClicks;
        FindObjectOfType<GamePlayUI>().CalculateStars(minClicks);
    }
    void UnlockNextLevel()
    {

    }
    void UnlockNextGalaxy()
    {

    }
}
