using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    GamePlayUI gamePlayUI;
    public void GoToMainMenu()
    {
        if (gamePlayUI == null) gamePlayUI = FindObjectOfType<GamePlayUI>();

        //Loading menu
        gamePlayUI.EnableLoadingScreen();
        Invoke("DisableLoadingScreen", 3f);
       
        Invoke("GoToMainMenuSequencing", 2.9f);
    }

    private void GoToMainMenuSequencing()
    {
        //Close all the levels
        FindObjectOfType<NextLevelSequence>().DisableAllLevels();

        //Enable the main menu
        gamePlayUI.EnableMainMenu();
        FindObjectOfType<MainMenuManager>().GoToGalaxy(1);

        //Reset everything under current game object

        //Disable current system
        gameObject.SetActive(false);
    }

    void DisableLoadingScreen()
    {
        if (gamePlayUI == null) gamePlayUI = FindObjectOfType<GamePlayUI>();
        gamePlayUI.DisableLoadingScreen();
    }
}
