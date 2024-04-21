using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    //Accessed from the serialised field only
    [SerializeField] public int Level; 
    [SerializeField] public int Galaxy;
    [SerializeField] public int MinClicks;

    private void OnEnable()
    {
        FindObjectOfType<NextLevelSequence>().CurrentLevelIndex(Level);//Its getting set from here so the issue is in "Level"

        PlayerPrefs.SetInt(PrefsHandler.currentLevel, Level);
        PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, Galaxy);
        PlayerPrefs.SetInt(PrefsHandler.minClick, MinClicks);

        Debug.Log("Level: " + Level + "- Galaxy: " + Galaxy);

        PlayerPrefs.SetInt(PrefsHandler.UnlockedGalaxy, Level + 1);
    }
}
