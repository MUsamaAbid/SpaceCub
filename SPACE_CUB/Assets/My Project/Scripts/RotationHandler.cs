using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] GameObject SpriteChangingCube;
    public float speed = 100f;

    public bool allowRotation;
    public bool stop;

    IEnumerator myRotationCoroutine;

    Quaternion TargetRot;

    private IEnumerator coroutine;

    float initialSpeed;

    void Start()
    {
        allowRotation = false;
        stop = false;
        initialSpeed = speed;
    }
    public void AllowRotation()
    {
        myRotationCoroutine = IncreaseSpeed();
        StartCoroutine(myRotationCoroutine);

        allowRotation = true;
        if (SpriteChangingCube.GetComponent<SpriteChanging>())
            SpriteChangingCube.GetComponent<SpriteChanging>().StartCoroutines();
        Debug.Log("Rotation continued");
    }
    public void StopRotation()
    {
        StopCoroutine(myRotationCoroutine);
        Invoke("StopRotationLocally", 15f);
    }
    public void StopRotationInstantly()
    {
        //allowRotation = false;
        //stop = true;
        //TargetRot = Quaternion.identity;
        //StopCoroutine(myRotationCoroutine);
        StopRotationLocally();
    }
    IEnumerator IncreaseSpeed()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);
            speed += speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (allowRotation)
        {
            transform.RotateAround(transform.position, -Vector3.forward, speed * Time.deltaTime);
            Debug.Log("Rotation of stars continued");
        }
        if (stop)
        {
            speed -= (10 * Time.deltaTime);
            allowRotation = false;

            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRot, Time.time * speed);
            //Debug.Log("Current rotation: " + transform.rotation);
            if (transform.rotation.z == TargetRot.z)
            {
                Debug.Log("Target Rotation achieved " + TargetRot);
                allowRotation = false;
                stop = false;
                transform.rotation = TargetRot;
                ResetSpeed();
                //FindObjectOfType<NextLevelSequence>().NextLevelCubesSetup();
                //gameObject.SetActive(false);
            }
        }
    }
    public void StopRotationLocally()
    {
        StopRotation(Quaternion.identity);
    }
    public void StopRotation(Quaternion TargetRot)
    {
        this.TargetRot = TargetRot;
        stop = true;
        allowRotation = false;
        Debug.Log("Allow Rotation: " + allowRotation);
        Debug.Log("Target Rotation - Rotation Stopped " + TargetRot + "- GameObject: " + gameObject.name);
    }
    public void ResetSpeed()
    {
        speed = initialSpeed;
    }
    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}