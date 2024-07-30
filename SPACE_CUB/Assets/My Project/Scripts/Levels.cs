using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] GameObject[] Galaxy1;
    [SerializeField] GameObject[] Galaxy2;
    [SerializeField] GameObject[] Galaxy3;

    public void StartLevel(int galaxy, int level)
    {
        if(galaxy == 0)
        {
            Debug.Log("Testing: Level: " + level);
            Debug.Log("Galaxy: " + galaxy + " of level: " + (level - 1));
            Galaxy1[level - 1].SetActive(true);
        }
        else if(galaxy == 1)
        {
            Galaxy1[level - 1].SetActive(true);
        }
        else if(galaxy == 2)
        {
            Galaxy1[level - 1].SetActive(true);
        }
    }
}
