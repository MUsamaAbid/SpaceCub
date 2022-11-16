using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IntroRotation : MonoBehaviour
{
    public float speed = 1000f;

    bool allowRotation;
    bool stop;

    Quaternion TargetRot;

    private void Start()
    {
        AllowRotation();
    }
    public void AllowRotation()
    {
        //StartCoroutine("IncreaseSpeed");
        allowRotation = true;
    }
    IEnumerator IncreaseSpeed()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);
            speed += speed;
        }
    }

    void Update()
    {
        if (allowRotation)
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
}
