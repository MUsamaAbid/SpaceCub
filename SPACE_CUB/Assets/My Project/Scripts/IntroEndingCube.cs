using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroEndingCube : MonoBehaviour
{
    public float speed = 1000f;

    bool allowRotation;

    [SerializeField] Image image;
    [SerializeField] Sprite SecondLastFrame;
    [SerializeField] Sprite LastFrame;

    private void OnEnable()
    {
        if(!image) image = GetComponent<Image>();

        AllowRotation();
        Invoke("StopRotation", 0.4f);
        Invoke("ChangeSprite", 0.4f);
    }
    void ChangeSprite()
    {
        StartCoroutine(ChangeSprites());
    }
    IEnumerator ChangeSprites()
    {
        image.sprite = SecondLastFrame;
        image.SetNativeSize();
        yield return new WaitForSeconds(0.02f);
        image.sprite = LastFrame;
        image.SetNativeSize();
    }
    void AllowRotation()
    {
        allowRotation = true;
    }
    void StopRotation()
    {
        transform.rotation = Quaternion.identity;
        allowRotation = false;
    }
    void Update()
    {
        if (allowRotation)
            transform.RotateAround(transform.position, -Vector3.forward, speed * Time.deltaTime);
    }
}
