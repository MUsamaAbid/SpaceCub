using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject LevelsScreen;
    [SerializeField] GameObject GalaxiesScreen;
    [SerializeField] GameObject MainMenu;

    [Header("Galaxies")]
    [SerializeField] GameObject Galaxy1;
    [SerializeField] GameObject Galaxy2;
    [SerializeField] GameObject Galaxy3;

    [Header("Loading Screen")]
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject LoadingFiller;

    [Header("Locks")]
    [SerializeField] GameObject Lock2;
    [SerializeField] GameObject Lock3;

    int currentLevel;

    private void OnEnable()
    {
        int unlockedGalaxy = PlayerPrefs.GetInt(PrefsHandler.UnlockedGalaxy);
        Debug.Log("Unlocked Galaxy: " + unlockedGalaxy);
        if(unlockedGalaxy == 2)
        {
            Lock2.SetActive(false);
        }
        else if(unlockedGalaxy == 3)
        {
            Lock2.SetActive(false);
            Lock3.SetActive(false);
        }
        else
        {
            Lock2.SetActive(true);
            Lock3.SetActive(true);
        }
    }

    public void GoToMainMenu()
    {
        if(FindObjectOfType<MMLevelEnabler>())
          FindObjectOfType<MMLevelEnabler>().CloseAllLevels();
        
        EnableLoadingScreen();
        Invoke("DisableGalaxy", 3f);
        Invoke("DisableLoadingScreen", 3f);
        //Enable main menu
        MainMenu.SetActive(true);

    }
    void EnableLoadingScreen()
    {
        LoadingScreen.SetActive(true);
      
        LoadingFiller.SetActive(true);
        LoadingFiller.GetComponent<Animator>().SetTrigger("Fill");
    }
    void DisableLoadingScreen()
    {
        LoadingScreen.SetActive(false);

        LoadingFiller.SetActive(false);
        LoadingFiller.GetComponent<Animator>().SetTrigger("Reset");
        Debug.Log("Loading screen disabled");
    }
    void DisableGalaxy()
    {
        Galaxy1.SetActive(false);
        Galaxy2.SetActive(false);
        Galaxy3.SetActive(false);

        GalaxiesScreen.SetActive(false);
        //MainMenu.SetActive(false);
            
        //DisableLoadingScreen();
        
        //gameObject.SetActive(false);
        Debug.Log("Main Menu manager should be disabled");
    }
    public void StartLevel(int level)
    {
        EnableLoadingScreen();
        //FindObjectOfType<MMLevelEnabler>().CloseAllLevels();

        currentLevel = level;
        Invoke("GoToLevel",3f);
    }

    private void GoToLevel()
    {
        int level = currentLevel;

        LevelsScreen.SetActive(true);
        int galaxy = PlayerPrefs.GetInt(PrefsHandler.currentGalaxy);
        Debug.Log("Testing: Current galaxy is: " + galaxy);
        FindObjectOfType<Levels>().StartLevel(galaxy, level);

        MainMenu.SetActive(false);

        DisableGalaxy();
        DisableLoadingScreen();
        gameObject.SetActive(false);
    }
    public void GoToGalaxy(int galaxy)
    {
        GalaxiesScreen.SetActive(true);
        if (galaxy == 1)
        {
            Galaxy1.SetActive(true);
        }
        else if (galaxy == 2)
        {
            Galaxy2.SetActive(true);
        }
        else if (galaxy == 3)
        {
            Galaxy3.SetActive(true);
        }
    }
}
