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

    Degree2CentreUp,
    Degree2CentreDown,

    Degree2UpRight,
    Degree2UpLeft,

    Degree2DownLeft,
    Degree2DownRight,

    Degree2UpDoubleRight,
    Degree2UpDoubleLeft,

    Degree2DownDoubleLeft,
    Degree2DownDoubleRight,

    Degree2TripleRight,
    Degree2TripleLeft,

    Degree3Top,
    Degree3Down,

    Degree3TopRight1,
    Degree3TopRight2,

    Degree3TopLeft1,
    Degree3TopLeft2,

    Degree3CentreRight1,
    Degree3CentreRight2,
    Degree3CentreRight3,
    Degree3CentreRight4,

    Degree3CentreLeft1,
    Degree3CentreLeft2,
    Degree3CentreLeft3,
    Degree3CentreLeft4,

    Degree3BottomRight1,
    Degree3BottomRight2,

    Degree3BottomLeft1,
    Degree3BottomLeft2,
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

    float speed;
    private void Start()
    {
        speed = 250f;
        movement = false;
    }
    public void StartMovement(MovementDegree movementDegree)
    {
        if (cubeDegree == CubeDegree.Degree1Centre)
        {
            if (movementDegree == MovementDegree.Spreaded)
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
        else if (cubeDegree == CubeDegree.Degree1CentreUp)
        {
            if (movementDegree == MovementDegree.Spreaded)
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
        else if (cubeDegree == CubeDegree.Degree2CentreUp)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(0, 368, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(0, 184, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(0, 276, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree1CentreDown)
        {
            if (movementDegree == MovementDegree.Spreaded)
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
        else if (cubeDegree == CubeDegree.Degree2CentreDown)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(0, -368, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(0, -184, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(0, -276, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree1DownLeft)
        {
            if (movementDegree == MovementDegree.Spreaded)
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
        else if (cubeDegree == CubeDegree.Degree1UpLeft)
        {
            if (movementDegree == MovementDegree.Spreaded)
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
        else if (cubeDegree == CubeDegree.Degree1DownRight)
        {
            if (movementDegree == MovementDegree.Spreaded)
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
        else if (cubeDegree == CubeDegree.Degree1UpRight)
        {
            if (movementDegree == MovementDegree.Spreaded)
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
        else if (cubeDegree == CubeDegree.Degree2UpRight)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(160, 276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(80, 138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(120, 207, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2UpLeft)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-160, 276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-80, 138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-120, 207, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2DownLeft)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-160, -276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-80, -138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-120, -207, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2DownRight)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(160, -276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(80, -138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(120, -207, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2UpDoubleRight)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(320, 184, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(160, 92, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(240, 138, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2DownDoubleRight)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(320, -184, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(160, -92, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(240, -138, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2UpDoubleLeft)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-320, 184, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-160, 92, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-240, 138, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2DownDoubleLeft)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-320, -184, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-160, -92, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-240, -138, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2TripleRight)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(320, 0, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(160, 0, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(240, 0, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree2TripleLeft)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-320, 0, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-160, 0, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-240, 0, 0);
            }
            speed = 500f;
        }
        else if (cubeDegree == CubeDegree.Degree3Top)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(0, 552, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(0, 276, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(0, 414, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3Down)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(0, -552, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(0, -276, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(0, -414, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3TopRight1)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(160, 460, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(80, 230, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(120, 345, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3TopLeft1)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-160, 460, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-80, 230, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-120, 345, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3BottomRight1)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(160, -460, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(80, -230, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(120, -345, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3BottomLeft1)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-160, -460, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-80, -230, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-120, -345, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3TopRight2)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(320, 368, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(160, 184, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(240, 276, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3TopLeft2)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-320, 368, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-160, 184, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-240, 276, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3BottomRight2)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(320, -368, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(160, -184, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(240, -276, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3BottomLeft2)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-320, -368, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-160, -184, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-240, -276, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreRight1)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(480, 276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(240, 138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(360, 207, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreRight2)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(480, 92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(240, 46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(360, 69, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreRight3)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(480, -92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(240, -46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(360, -69, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreLeft3)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-480, -92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-240, -46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-360, -69, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreLeft1)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-480, 276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-240, 138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-360, 207, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreLeft2)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-480, 92, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-240, 46, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-360, 69, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreRight4)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(480, -276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(240, -138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(360, -207, 0);
            }
            speed = 750f;
        }
        else if (cubeDegree == CubeDegree.Degree3CentreLeft4)
        {
            if (movementDegree == MovementDegree.Spreaded)
            {
                TargetPos = new Vector3(-480, -276, 0);
            }
            else if (movementDegree == MovementDegree.Centre)
            {
                TargetPos = new Vector3(-240, -138, 0);
            }
            else if (movementDegree == MovementDegree.GamePlay)
            {
                TargetPos = new Vector3(-360, -207, 0);
            }
            speed = 750f;
        }
        movement = true;
    }
    private void FixedUpdate()
    {
        if(movement)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPos, Time.deltaTime * speed);
        
        if (transform.localPosition == TargetPos) movement = false;
    }
}
