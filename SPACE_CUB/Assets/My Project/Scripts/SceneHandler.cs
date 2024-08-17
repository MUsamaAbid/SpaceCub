using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject MenuScreen;
    [SerializeField] GameObject GamePlayScreen;

    [SerializeField] GameObject[] Galaxy1Levels;

    [SerializeField] GameObject[] Galaxy2Levels;

    [SerializeField] GameObject[] Galaxy3Levels;

    int galaxy;

    private void OnEnable()
    {
        galaxy = PlayerPrefs.GetInt(PrefsHandler.currentGalaxy); //0 is for 1
        Debug.Log("Testing: Current galaxy in Scene Handler: " + galaxy);

        if (PlayerPrefs.GetInt(PrefsHandler.SceneUnlock) == 3)
        {
            StartScreen.SetActive(false);
            MenuScreen.SetActive(false);
            GamePlayScreen.SetActive(true);

            int level = PlayerPrefs.GetInt(PrefsHandler.currentLevel) + 1;
            galaxy = PlayerPrefs.GetInt(PrefsHandler.currentGalaxy); //0 is for 1

            FindObjectOfType<Levels>().StartLevel(galaxy, level);
        }
        
        else if (PlayerPrefs.GetInt(PrefsHandler.SceneUnlock) == 1)
        {
            StartScreen.SetActive(false);
            MenuScreen.SetActive(true);

            FindObjectOfType<MainMenuManager>().OpenGalaxy(galaxy + 1);
        }
        
        PlayerPrefs.SetInt(PrefsHandler.SceneUnlock, 0);
    }

    public void LoadLevel()
    {
        PlayerPrefs.SetInt(PrefsHandler.SceneUnlock, 3);
        ReloadScene();
    }
    
    public void LoadLevelSelection()
    {
        PlayerPrefs.SetInt(PrefsHandler.SceneUnlock, 1);
        SceneManager.LoadScene(0);
    }
    public void ReloadScene()
    {
        foreach(var l in Galaxy1Levels)
        {
            l.SetActive(false);
        }
        foreach (var l in Galaxy2Levels)
        {
            l.SetActive(false);
        }
        foreach (var l in Galaxy3Levels)
        {
            l.SetActive(false);
        }

        SceneManager.LoadScene(0);
    }
}
