using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterEnable : MonoBehaviour
{
    [SerializeField] GameObject currentObject;

    [SerializeField] float disableAfter;
    
    private void OnEnable()
    {
        if (!currentObject) currentObject = gameObject;
        Invoke("DisableGameObject", disableAfter);
    }
    void DisableGameObject()
    {
        currentObject.SetActive(false);
    }
}
