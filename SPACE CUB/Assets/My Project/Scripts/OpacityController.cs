using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityController : MonoBehaviour
{
    Image image;
    float val;
    Color temp;

    private void Start()
    {
        image = GetComponent<Image>();
        temp = image.color;
        val = 1;
    }
    private void OnEnable()
    {
        
    }
    private void Update()
    {
        val -= Time.deltaTime * 0.001f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, val);
        
    }
}
