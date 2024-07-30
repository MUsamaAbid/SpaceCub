using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMLevelEnabler : MonoBehaviour
{
    [SerializeField] EnableLevel[] Levels;
    Coroutine mapCoroutine;

    [SerializeField] GameObject GalaxyGameObject;
    [SerializeField] int Galaxy;

    [SerializeField] GameObject NextButton;

    private void OnEnable()
    {
        SetCurrentGalaxyInMenu();
        EnableAllLevels();
    }
    private void Start()
    {
        //EnableLevel(0);
        //EnableAllLevels();

        if(Galaxy == 1)
        {
            if(PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy2) > 19)
            {
                NextButton.SetActive(true);
            }
        }
    }
    void SetCurrentGalaxyInMenu()
    {
        if (Galaxy == 0)
        {
            PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, 0);
        }
        else if (Galaxy == 1)
        {
            PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, 1);
        }
        else if (Galaxy == 2)
        {
            PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, 2);
        }
    }
    void EnableAllLevels()
    {
        mapCoroutine = StartCoroutine(OpenMap());
    }
    IEnumerator OpenMap()
    {
        //Get the galaxy and thn set the opened Levels to openLevel
        int openLevel;
        if (Galaxy == 0)
        {
            openLevel = PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy1);
        }
        else if (Galaxy == 1)
        {
            openLevel = PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy2);
        }
        else
        {
            openLevel = PlayerPrefs.GetInt(PrefsHandler.unlockedLevelGalaxy3);
        }
        //for (int i = 0; i <= Levels.Length - 1; i++)

        if (openLevel == 0) openLevel = 1;

        for (int i = 0; i <= openLevel - 1; i++)
        {
            Levels[i].GetComponent<EnableLevel>().EnableCurrentLevel();
            yield return new WaitForSeconds(0.2f);
        }
        //GalaxyGameObject.SetActive(false);
    }
    void EnableLevel(int levelNumber)
    {
        if (levelNumber > Levels.Length - 1)
        {
            Debug.LogError("Level count doesnt exist");
            return;
        }
        Levels[levelNumber].GetComponent<EnableLevel>().EnableCurrentLevel();
        //Levels[levelNumber].
    }
    private void OnDisable()
    {
        CloseAllLevels();
        //Debug.Log("DISABLE");
    }
    public void CloseAllLevels()
    {
        if(mapCoroutine != null)
            StopCoroutine(mapCoroutine);
        
        StartCoroutine(CloseMap());
        //Debug.Log("COROUTINE foR MAP OPENIng STOPped");
    }
    IEnumerator CloseMap()
    {
        for (int i = 0; i <= Levels.Length - 1; i++)
        {
            Levels[i].GetComponent<EnableLevel>().CloseCurrentLevel();
            yield return new WaitForSeconds(0f);
        }
    }
    public void GotoLevel(int level)
    {
        CloseAllLevels();
        //GalaxyGameObject.SetActive(false);
        Debug.Log("Testing: Level sent: " + level);
        FindObjectOfType<MainMenuManager>().StartLevel(level);
    }
}
