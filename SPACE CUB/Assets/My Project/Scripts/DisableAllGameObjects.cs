using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAllGameObjects : MonoBehaviour
{
    [SerializeField] GameObject[] GameObjects;

    public void DisableObejcts()
    {
        for (int i = 0; i < GameObjects.Length; i++)
        {
            GameObjects[i].SetActive(false);
        }
    }
}
