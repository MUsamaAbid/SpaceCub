using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] GameObject SpriteChangingCube;
    public float speed = 100f;

    bool allowRotation;
    bool stop;

    IEnumerator myRotationCoroutine;

    Quaternion TargetRot;

    private IEnumerator coroutine;

    void Start()
    {
        allowRotation = false;
        stop = false;
    }
    public void AllowRotation()
    {
        myRotationCoroutine = IncreaseSpeed();
        StartCoroutine(myRotationCoroutine);

        allowRotation = true;
        if(SpriteChangingCube.GetComponent<SpriteChanging>())
            SpriteChangingCube.GetComponent<SpriteChanging>().StartCoroutines();
    }
    public void StopRotation()
    {
        StopCoroutine(myRotationCoroutine);
        Invoke("StopRotationLocally", 15f);
    }
    IEnumerator IncreaseSpeed()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);
            speed += speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(allowRotation)
        transform.RotateAround(transform.position, -Vector3.forward, speed * Time.deltaTime);
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
                //FindObjectOfType<NextLevelSequence>().NextLevelCubesSetup();
                //gameObject.SetActive(false);
            }
        }
    }
    void StopRotationLocally()
    {
        StopRotation(Quaternion.identity);
    }
    public void StopRotation(Quaternion TargetRot)
    {
        this.TargetRot = TargetRot;
        stop = true;
        Debug.Log("Target Rotation " + TargetRot);
    }
}
