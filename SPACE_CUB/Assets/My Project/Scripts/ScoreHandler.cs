using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] int[] MaxScore;

    float min, sec, milli;
    float maxTime;
    float totalTime;

    float score;
    public void SetTime(float min, float sec, float milli)
    {
        this.min = min;
        this.sec = sec;
        this.milli = milli;

        CalculateScore();
    }
    void CalculateScore()
    {
        int galaxy, level, minClicks;
        
        galaxy = PlayerPrefs.GetInt(PrefsHandler.currentGalaxy);
        level = PlayerPrefs.GetInt(PrefsHandler.currentLevel);
        minClicks = PlayerPrefs.GetInt(PrefsHandler.minClick);
        milli = (milli / 10);
        totalTime = (min * 60) + (sec) + (milli / 10);

        if(galaxy == 0)
        {
            if (totalTime >= 30) score = 0;
            else
            {
                score = (30 - totalTime) * 100;
            }
        }
        else if(galaxy == 1)
        {
            if (totalTime >= 60) score = 0;
            else
            {
                score = (60 - totalTime) * 100;
            }
        }
        else if(galaxy == 2)
        {
            if (totalTime >= 90) score = 0;
            else
            {
                score = (90 - totalTime) * 100;
            }
        }
        if (PlayerPrefs.GetInt(PrefsHandler.stars) == 1) score += 1000;
        else if (PlayerPrefs.GetInt(PrefsHandler.stars) == 2) score += 2000;
        else if (PlayerPrefs.GetInt(PrefsHandler.stars) == 3) score += 3000;

        FindObjectOfType<GamePlayUI>().UpdateScore(score.ToString());
        Debug.Log("Score::: " + score);
    }
}
