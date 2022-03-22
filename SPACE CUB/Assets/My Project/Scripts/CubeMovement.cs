using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeDegree
{
    Degree1Centre,

    Degree1UpLeft,
    Degree1DownLeft,

    Degree1DownRight,
    Degree1UpRight,

    Degree1CentreUp,
    Degree1CentreDown,
}
public enum MovementDegree
{
    Spreaded,
    Centre,
    GamePlay
}
public class CubeMovement : MonoBehaviour
{
    [SerializeField] CubeDegree cubeDegree;
    //[SerializeField] MovementDegree movementDegree;

    public bool movement;

    Vector3 TargetPos;

    private void Start()
    {
        movement = false;
    }
    public void StartMovement(MovementDegree movementDegree)
    {
        if(cubeDegree == CubeDegree.Degree1Centre)
        {
            if(movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(0, 0, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(0, 0, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(0, 0, 0);
            }
        }
        else if(cubeDegree == CubeDegree.Degree1CentreUp)
        {
            if(movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(0, 184, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(0, 92, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(0, 138, 0);
            }
        }
        else if(cubeDegree == CubeDegree.Degree1CentreDown)
        {
            if(movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(0, -184, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(0, -92, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(0, -138, 0);
            }
        } 
        else if(cubeDegree == CubeDegree.Degree1DownLeft)
        {
            if(movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-160, -92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-80, -46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-120, -69, 0);
            }
        }
        else if(cubeDegree == CubeDegree.Degree1UpLeft)
        {
            if(movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-160, 92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-80, 46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-120, 69, 0);
            }
        }
        else if(cubeDegree == CubeDegree.Degree1DownRight)
        {
            if(movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(160, -92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(80, -46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(120, -69, 0);
            }
        }
        else if(cubeDegree == CubeDegree.Degree1UpRight)
        {
            if(movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(160, 92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(80, 46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(120, 69, 0);
            }
        }

        movement = true;
    }
    private void FixedUpdate()
    {
        if(movement)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPos, Time.deltaTime * 250);
        
        if (transform.localPosition == TargetPos) movement = false;
    }
}
