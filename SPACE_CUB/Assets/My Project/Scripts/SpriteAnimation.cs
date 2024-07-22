using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class SpriteChanger
{
    public Image TargetSprite;
    public float interval;
    public Sprite[] sprites;
    public bool ifSetNative;
}
public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] public SpriteChanger[] spriteChanger;
    [SerializeField] int index = 0;

    Coroutine spriteCoroutine;
    
    public void StartFirstAnimation()
    {
        index = 0;
        StartCoroutine(ChangeSprites());
    }
    public void StartNextAnimation()
    {
        index++;
        if (index > spriteChanger.Length - 1) index = 0;

        spriteCoroutine = StartCoroutine(ChangeSprites());
    }
    IEnumerator ChangeSprites()
    {
        //Debug.Log("Time Now: " + Time.time);

        Sprite[] sprites = spriteChanger[index].sprites;
        //float interval = spriteChanger[index].interval;
        float interval = 0.0050505f;

        GameObject TargetSprite = spriteChanger[index].TargetSprite.gameObject;
        bool ifSetNative = spriteChanger[index].ifSetNative;

        for (int i = 0; i <= sprites.Length - 1; i++)
        {
            TargetSprite.gameObject.GetComponent<Image>().sprite = sprites[i];
            if (ifSetNative) spriteChanger[index].TargetSprite.SetNativeSize();
            yield return new WaitForSeconds(interval);
        }
        //Debug.Log("Time Now: " + Time.time);
    }
    public void CloseAnimation()
    {
        if(spriteCoroutine != null)
        {
            StopCoroutine(spriteCoroutine);
           // Debug.Log("SpriteChanging Coroutine stopped");
        }

        Sprite[] sprites = spriteChanger[index].sprites;
        float interval = spriteChanger[index].interval;
        GameObject TargetSprite = spriteChanger[index].TargetSprite.gameObject;
        bool ifSetNative = spriteChanger[index].ifSetNative;

        TargetSprite.gameObject.GetComponent<Image>().sprite = sprites[sprites.Length - 1];
//        Debug.Log("TargetSprite: " + TargetSprite.gameObject.name + " Image attached: " + sprites[sprites.Length - 1].name);

        if (ifSetNative) spriteChanger[index].TargetSprite.SetNativeSize();
    }
}
