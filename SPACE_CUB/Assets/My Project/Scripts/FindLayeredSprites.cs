using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLayeredSprites : MonoBehaviour
{
    [SerializeField] public GameObject[] OverlappingSprites;
    public int GetSiblingCount()
    {
        return transform.GetSiblingIndex();
    }
}
