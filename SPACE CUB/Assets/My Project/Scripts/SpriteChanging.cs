using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanging : MonoBehaviour
{
    [SerializeField] GameObject TargetSprite;

    [SerializeField] Sprite[] Sprites;
    [SerializeField] Sprite[] NextLevelSprite;

    [SerializeField] float intervalBetweenSprites;

    public bool ifSetNative;
    
    public bool ifRescale;
    public float RescaleAfter;
    public void StartCoroutines()
    {
        StartCoroutine("StartChanging");
    }
    public void StartCoroutineAfterInterval(float f)
    {
        Invoke("StartCoroutines", f);
    }
    IEnumerator StartChanging()
    {
        for(int i = 0; i < Sprites.Length; i++)
        {
            yield return new WaitForSeconds(intervalBetweenSprites);

            TargetSprite.GetComponent<Image>().sprite = Sprites[i];
            if(ifSetNative)
            TargetSprite.GetComponent<Image>().SetNativeSize();

            if (i == Sprites.Length - 1)
            {
                if (ifRescale)
                {
                   Invoke("Rescale", RescaleAfter);
                   Invoke("StartNextLevelCoroutine", 5);
                }
            }
        }
    }
    void StartNextLevelCoroutine()
    {
        StartCoroutine("StartNextLevel");
    }
    IEnumerator StartNextLevel()
    {
        for (int i = 0; i < NextLevelSprite.Length; i++)
        {
            yield return new WaitForSeconds(intervalBetweenSprites);

            TargetSprite.GetComponent<Image>().sprite = NextLevelSprite[i];
            if (ifSetNative)
                TargetSprite.GetComponent<Image>().SetNativeSize();

            if (i == Sprites.Length - 1)
            {
                if (ifRescale)
                    Invoke("Rescale", RescaleAfter);
            }
        }
    }
    private void Rescale()
    {
        TargetSprite.GetComponent<Animator>().SetTrigger("Rescale");
    }
}
