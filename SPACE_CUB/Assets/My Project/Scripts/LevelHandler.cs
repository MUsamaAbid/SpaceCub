using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] public int Level;
    [SerializeField] public int Galaxy;
    [SerializeField] public int MinClicks;

    private void OnEnable()
    {
        FindObjectOfType<NextLevelSequence>().CurrentLevelIndex(Level);

        PlayerPrefs.SetInt(PrefsHandler.currentLevel, Level);
        PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, Galaxy);
        PlayerPrefs.SetInt(PrefsHandler.minClick, MinClicks);
    }
}
