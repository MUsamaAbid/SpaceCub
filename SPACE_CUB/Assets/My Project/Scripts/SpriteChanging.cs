using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanging : MonoBehaviour
{
    [SerializeField] GameObject TargetSprite;

    [SerializeField] Sprite RGBSprite;
    [SerializeField] Sprite SimpleCube;
    [SerializeField] Sprite HexagonCube;
    [SerializeField] Sprite SmoothCircularWhite;

    [SerializeField] Sprite[] RotationSprite;
    [SerializeField] Sprite[] Sprites;
    [SerializeField] Sprite[] NextLevelSprite;

    [SerializeField] GameObject WhiteSprite;

    [SerializeField] float intervalBetweenSprites;
    [SerializeField] float intervalBetweenNextLevelSprites;

    public bool ifSetNative;
    
    public bool ifRescale;
    public float RescaleAfter;

    private void OnEnable()
    {
        //TargetSprite.GetComponent<Image>().sprite = RGBSprite;
        //if (ifSetNative)
        //    TargetSprite.GetComponent<Image>().SetNativeSize();
    }
    public void StartRotation()
    {
        //GetComponent<Animator>().runtimeAnimatorController = rotationAnimator;
        StartCoroutine("StartRotationCoroutine");
    }
    IEnumerator StartRotationCoroutine()
    {
        for (int i = 0; i < RotationSprite.Length; i++)
        {
            yield return new WaitForSeconds(0.001f);
            TargetSprite.GetComponent<Image>().sprite = RotationSprite[i];
        }
    }
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
            if (ifSetNative)
                TargetSprite.GetComponent<Image>().SetNativeSize();
            if (i == Sprites.Length - 1)
            {
                if(WhiteSprite)
                    WhiteSprite.SetActive(true);
                Invoke("StartRescaling", 0);
            }
            //if (i == Sprites.Length - 1)
        }
    }

    private void StartRescaling()
    {
        if (ifRescale)
        {
            Invoke("Rescale", RescaleAfter);
            Invoke("StartNextLevelCoroutine", 2f);
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
            yield return new WaitForSeconds(intervalBetweenNextLevelSprites);

            TargetSprite.GetComponent<Image>().sprite = NextLevelSprite[i];
            if (ifSetNative)
                TargetSprite.GetComponent<Image>().SetNativeSize();

            if (i == Sprites.Length - 1)
            {
                if (ifRescale)
                {
                    Invoke("Rescale", RescaleAfter);
                    Debug.Log("Rescaling done");
                }
            }
        }
        yield return new WaitForSeconds(1f);

        TargetSprite.GetComponent<Image>().sprite = SmoothCircularWhite;
        
        yield return new WaitForSeconds(0.8f);
        
        TargetSprite.GetComponent<Image>().sprite = HexagonCube;

        GetComponent<RotationHandler>().StopRotation(Quaternion.identity);

        yield return new WaitForSeconds(0.1f);
        
        TargetSprite.GetComponent<Image>().sprite = SimpleCube;
        
        gameObject.SetActive(false);

        FindObjectOfType<NextLevelSequence>().NextLevelCubesSetup();
    }
    private void Rescale()
    {
        TargetSprite.GetComponent<Animator>().SetTrigger("Rescale");
    }
    public void ChangeToRGBSprite()
    {
        TargetSprite.GetComponent<Image>().sprite = RGBSprite;
        Debug.Log("Changed to RGB sprite");
    }
    public void ResetToTheFirstSprite()
    {
        TargetSprite.GetComponent<Image>().sprite = Sprites[0];
        //TargetSprite.GetComponent<Image>().SetNativeSize();
    }
    public void ResetToFirstSpriteRotation()
    {
        TargetSprite.GetComponent<Image>().sprite = RotationSprite[0];
        TargetSprite.GetComponent<Image>().SetNativeSize();
    }
}
