using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int clicks;
    public int score;

    public float startTime;
    public float endTime;

    GamePlayUI gamePlayUI;

    private void Start()
    {
        gamePlayUI = FindObjectOfType <GamePlayUI>();

        clicks = 0;
        
        startTime = Time.time;
    }
    void EndingTime()
    {
        endTime = Time.time - startTime;
    }
    public void ClickCounter()
    {
        clicks++;
        if(!gamePlayUI) gamePlayUI = FindObjectOfType <GamePlayUI>();
        gamePlayUI.UpdateClicks(clicks.ToString());
    }
    public void ResetClicksAndScore()
    {
        clicks = 0; 
        score = 0;
    }
}
