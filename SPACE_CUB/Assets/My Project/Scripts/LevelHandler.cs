using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    //Should be accessed from the serialised field only
    [SerializeField] public int Level; 
    [SerializeField] public int Galaxy;
    [SerializeField] public int MinClicks;

    private void OnEnable()
    {
        FindObjectOfType<NextLevelSequence>().CurrentLevelIndex(Level);//Its getting set from here so the issue is in "Level"

        PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, Galaxy);
        PlayerPrefs.SetInt(PrefsHandler.minClick, MinClicks);

        if(Galaxy == 0)
        {
            Debug.Log("Testing: Galaxy 0 unlocked till level " + PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy1, 0)); ;

            if (PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy1, 0) < Level + 1)
            {
                PlayerPrefs.SetInt(PrefsHandler.unlockedLevelGalaxy1, Level + 1);
                Debug.Log("Testing: adding in Galaxy 1: " + Level + 1);
            }
        }
        else if(Galaxy == 1)
        {
            if (PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy2, 0) < Level + 1)
            {
                PlayerPrefs.SetInt(PrefsHandler.unlockedLevelGalaxy2, Level + 1);
            }
        }
        else if(Galaxy == 2)
        {
            if (PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy3, 0) < Level + 1)
            {
                PlayerPrefs.SetInt(PrefsHandler.unlockedLevelGalaxy3, Level + 1);
            }
        }

        Debug.Log("Testing: Level: " + Level + "- Galaxy: " + Galaxy);

        //PlayerPrefs.SetInt(PrefsHandler.UnlockedGalaxy, Level + 1);

        FindObjectOfType<GamePlayUI>().UpdateGalaxyAndLevel(Galaxy + 1, Level + 1);
    }
}
