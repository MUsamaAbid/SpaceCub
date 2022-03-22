using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    #region Public fields
    [Header("Texts")]
    [SerializeField] Text Score;
    [SerializeField] Text Clicks;
    [SerializeField] Text Time;

    [Header("Buttons")]
    [SerializeField] Button NextLevel;
    [SerializeField] Button Restart;
    [SerializeField] Button LevevlSelection;

    [SerializeField] Button BackButton;
    [SerializeField] Button SettingButton;
    #endregion

    [SerializeField] GameObject WhiteScreen1;
    [SerializeField] GameObject WhiteScreen2;
    [SerializeField] GameObject WhiteScreen3;

    [SerializeField] GameObject CongratulationsScreen;

    [SerializeField] GameObject Confetti;

    [SerializeField] GameObject TwoByTwoRGBCube;
    #region public functions

    #region UpdateFields
    public void UpdateScore(string s)
    {
        Score.text = "SCORE : " + s;
    } 
    public void UpdateClicks(string c)
    {
        Clicks.text = "CLICKS : " + c;
    } 
    public void UpdateTime(string t)
    {
        Time.text = "TIME : " + t;
    }
    #endregion

    public void StartWinScreen()
    {
        Invoke("DisplayCongratulationsScreen", 2.5f);
        Invoke("EnableTime", 3.5f);
        Invoke("EnableClicks", 4.5f);
        Invoke("EnableScore", 5.5f);
    }
    public void EnableLevelTwoWin()
    {
        TwoByTwoRGBCube.SetActive(true);
        FindObjectOfType<DisableAllGameObjects>().DisableObejcts();
        StartWinScreen();
    }
    #region Display Functions
    void DisplayCongratulationsScreen()
    {
        CongratulationsScreen.SetActive(true);
    }
    public void EnableScore()
    {
        Score.gameObject.SetActive(true);
        WhiteScreen2.SetActive(false);
        WhiteScreen3.SetActive(true);
        Invoke("EnableAllButtons", 0.5f);
        Invoke("DisableAllWhiteScreens", 0.5f);
        Invoke("DisableGamePlayButtons", 0.5f);
    }
    public void EnableClicks()
    {
        Clicks.gameObject.SetActive(true);
        WhiteScreen1.SetActive(false);
        WhiteScreen2.SetActive(true);

    }
    public void EnableTime()
    {
        Time.gameObject.SetActive(true);
        WhiteScreen1.SetActive(true);
    }
    void EnableAllButtons()
    {
        NextLevel.gameObject.SetActive(true);
        Restart.gameObject.SetActive(true);
        LevevlSelection.gameObject.SetActive(true);
    }
    void DisableAllWhiteScreens()
    {
        WhiteScreen1.SetActive(false);
        WhiteScreen2.SetActive(false);
        WhiteScreen3.SetActive(false);

        GameObject g = Instantiate(Confetti);
        g.transform.position = new Vector3(0, 0, 0);
    }
    void DisableGamePlayButtons()
    {
        BackButton.gameObject.SetActive(false);
        SettingButton.gameObject.SetActive(false);
    }
    #endregion
    public void DisableEndingUI()
    {
        Score.gameObject.SetActive(false);
        Clicks.gameObject.SetActive(false);
        Time.gameObject.SetActive(false);

        NextLevel.gameObject.SetActive(false);
        Restart.gameObject.SetActive(false);
        LevevlSelection.gameObject.SetActive(false);

        CongratulationsScreen.gameObject.SetActive(false);
    }
    public void DisableEndingUI(int i)
    {
        Invoke("DisableEndingUI", i);
    }
    #endregion
    public void StartNextButtonAnimation()
    {
        NextLevel.gameObject.GetComponent<Animator>().SetTrigger("Move");
    }
    public void StartNextButtonAnimation(int i)
    {
        Invoke("StartNextButtonAnimation", i);
    }
}
