using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] CubeMovement[] Cubes;

    private void Start()
    {
        GameStartSequence();
    }

    private void GameStartSequence()
    {
        Centre();
        Invoke("Spreaded", 2f);
        Invoke("GamePlayForm", 4f);
    }
    public void GameEndSequence()
    {
        Spreaded();
        Invoke("Centre", 1f);
        Invoke("GameUI", 1.5f);
    }
    void GameUI()
    {
        FindObjectOfType<GamePlayUI>().EnableLevelTwoWin();
    }
    public void GamePlayForm()
    {
        for (int i = 0; i < Cubes.Length; i++)
        {
            Cubes[i].StartMovement(MovementDegree.GamePlay);
        }
    }
    public void Spreaded()
    {
        for (int i = 0; i < Cubes.Length; i++)
        {
            Cubes[i].StartMovement(MovementDegree.Spreaded);
        }
    }
    public void Centre()
    {
        for (int i = 0; i < Cubes.Length; i++)
        {
            Cubes[i].StartMovement(MovementDegree.Centre);
        }
    }
}
