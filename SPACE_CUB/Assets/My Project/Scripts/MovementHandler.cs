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

    public void GameStartSequence()
    {
        Centre();
        Invoke("Spreaded", 2f);
        Invoke("GamePlayForm", 4f);
    }
    public void GameEndSequence()
    {
        if (FindObjectOfType<LevelHandler>().Galaxy > 0)
        {
            
            Invoke("StartGameEndSequence", 0.75f);
            Debug.Log("Galaxy not 0");
        }
        else
        {
            StartGameEndSequence();
        }
    }

    private void StartGameEndSequence()
    {
        if (FindObjectOfType<LevelHandler>().Galaxy == 1)
        {
            Spreaded();
            Invoke("Centre", 1f);
            Invoke("StartResizing3x3", 1.5f);
            Invoke("GameUI", 2f);
        }
        else if (FindObjectOfType<LevelHandler>().Galaxy == 2)
        {
            Spreaded();
            Invoke("Centre", 1f);
            Invoke("StartResizing4x4", 1.5f);
            Invoke("GameUI", 2f);
        }
        else
        {
            Debug.Log("Should start spreading");
            Spreaded();
            Invoke("Centre", 1f);
            Invoke("GameUI", 1.5f);
        }
    }

    void StartResizing3x3()
    {
        FindObjectOfType<DisableAllGameObjects>().DisableObejcts();
        FindObjectOfType<GamePlayUI>().Enable3x3Cube(true);
        FindObjectOfType<GamePlayUI>().StartResizingAnimation();
    }
    void StartResizing4x4()
    {
        FindObjectOfType<DisableAllGameObjects>().DisableObejcts();
        FindObjectOfType<GamePlayUI>().Enable4x4Cube(true);
        FindObjectOfType<GamePlayUI>().StartResizingAnimation();
    }

    void GameUI()
    {
        FindObjectOfType<GamePlayUI>().EnableLevelTwoWin();
    }
    public void GamePlayForm()
    {
        Debug.Log("Spread - GamePlay: " + gameObject.transform.parent.name);
        for (int i = 0; i < Cubes.Length; i++)
        {
            Cubes[i].StartMovement(MovementDegree.GamePlay);
        }
        FindObjectOfType<GamePlayUI>().StartTimer();
        FindObjectOfType<GamePlayUI>().DisplayLevelText();
    }
    public void Spreaded()
    {
        Debug.Log("Spread - Spreaded: " + gameObject.transform.parent.name);

        for (int i = 0; i < Cubes.Length; i++)
        {
            Cubes[i].StartMovement(MovementDegree.Spreaded);
        }
    }
    public void Centre()
    {
        Debug.Log("Spread - Centre: " + gameObject.transform.parent.name);

        for (int i = 0; i < Cubes.Length; i++)
        {
            Cubes[i].StartMovement(MovementDegree.Centre);
        }
    }
}
