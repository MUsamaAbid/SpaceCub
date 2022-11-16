using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToRGBSprite : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("ChangeToRGB", 1f);
    }
    void ChangeToRGB()
    {
        GetComponentInParent<SpriteChanging>().ChangeToRGBSprite();
    }
}
