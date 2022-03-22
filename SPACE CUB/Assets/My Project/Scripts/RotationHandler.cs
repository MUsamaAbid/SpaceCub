using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] GameObject SpriteChangingCube;
    bool allowRotation;
    // Start is called before the first frame update
    void Start()
    {
        allowRotation = false;
    }
    public void AllowRotation()
    {
        allowRotation = true;
        SpriteChangingCube.GetComponent<SpriteChanging>().StartCoroutines();
    }
    // Update is called once per frame
    void Update()
    {
        if(allowRotation)
        transform.RotateAround(transform.position, Vector3.forward, 100000 * Time.deltaTime);
    }
}
