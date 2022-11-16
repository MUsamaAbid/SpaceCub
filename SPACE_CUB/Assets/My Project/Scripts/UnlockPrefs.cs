using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPrefs : MonoBehaviour
{

    public void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt(PrefsHandler.level, level);
        Debug.Log("Level unlocked: " + PlayerPrefs.GetInt(PrefsHandler.level));
    }
    public void UnlockGalaxy(int galaxy)
    {
        PlayerPrefs.SetInt(PrefsHandler.galaxy, galaxy);
        Debug.Log("Galaxy unlocked: " + PlayerPrefs.GetInt(PrefsHandler.galaxy));
    }

}
