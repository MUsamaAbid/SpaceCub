using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsHandler : MonoBehaviour
{
    public static string Intro = "Intro";

    public static string currentGalaxy = "currentGalaxy";
    public static string currentLevel = "currentLevel";
    public static string stars = "currentStars";
    public static string minClick = "minClicks";

    #region Unlock Level
    public static string galaxy = "galaxy";
    public static string level = "level";
    #endregion

    public static string unlockedLevelGalaxy1 = "unlockedLevelGalaxy1";
    public static string unlockedLevelGalaxy2 = "unlockedLevelGalaxy2";
    public static string unlockedLevelGalaxy3 = "unlockedLevelGalaxy3";

    public static string UnlockedGalaxy = "UnlockedGalaxy";

    public static string SceneUnlock = "SceneUnlock";

    public void ResetPrefs()
    {
        PlayerPrefs.SetInt(Intro, 0);
        PlayerPrefs.SetInt(unlockedLevelGalaxy1, 0);
        PlayerPrefs.SetInt(unlockedLevelGalaxy2, 0);
        PlayerPrefs.SetInt(unlockedLevelGalaxy3, 0);
        PlayerPrefs.SetInt(UnlockedGalaxy, 0);
        PlayerPrefs.SetInt(SceneUnlock, 0);
    }
}
