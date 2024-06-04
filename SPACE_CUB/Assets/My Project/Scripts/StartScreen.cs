using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject StartScreenPanel;
    [SerializeField] GameObject Intro;

    [SerializeField] GameObject MainMenu;

    public void LoadIntroFirstTime()
    {
        if(PlayerPrefs.GetInt(PrefsHandler.Intro) == 0)
        {
            PlayerPrefs.SetInt(PrefsHandler.Intro, 1);
            Intro.SetActive(true);
        }
        else
        {
            StartScreenPanel.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
    public void LoadIntro()
    {
        Intro.SetActive(true);
    }
}
