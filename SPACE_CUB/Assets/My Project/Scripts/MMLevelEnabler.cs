using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMLevelEnabler : MonoBehaviour
{
    [SerializeField] EnableLevel[] Levels;
    Coroutine mapCoroutine;

    [SerializeField] GameObject GalaxyGameObject;
    [SerializeField] int Galaxy;

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
    private void Start()
    {
        //EnableLevel(0);
        //EnableAllLevels();
    }
    void EnableAllLevels()
    {
        mapCoroutine = StartCoroutine(OpenMap());
    }
    IEnumerator OpenMap()
    {
        for (int i = 0; i <= Levels.Length - 1; i++)
        {
            Levels[i].GetComponent<EnableLevel>().EnableCurrentLevel();
            yield return new WaitForSeconds(0.6f);
        }
        //GalaxyGameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CloseAllLevels();
        Debug.Log("DISABLE");
    }
    public void CloseAllLevels()
    {
        if(mapCoroutine != null)
            StopCoroutine(mapCoroutine);
        
        StartCoroutine(CloseMap());
        Debug.Log("COROUTINE foR MAP OPENIng STOPped");
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
        FindObjectOfType<MainMenuManager>().StartLevel(level);
    }

    private void OnEnable()
    {
        SetCurrentGalaxyInMenu();
        EnableAllLevels();
    }
    void SetCurrentGalaxyInMenu()
    {
        if (Galaxy == 1)
        {
            PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, 0);
        }
        else if (Galaxy == 2)
        {
            PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, 1);
        }
        else if (Galaxy == 3)
        {
            PlayerPrefs.SetInt(PrefsHandler.currentGalaxy, 2);
        }
    }
}
