using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Stars
{ 
    OneStar,
    TwoStar,
    ThreeStar
}

public class GamePlayUI : MonoBehaviour
{
    #region Public fields
    [Header("Texts")]
    [SerializeField] Text ScoreText;
    [SerializeField] Text ClicksText;
    [SerializeField] Text TimeText;
    [SerializeField] Text MinsText;
    [SerializeField] Text SecondsText;
    [SerializeField] Text MilliText;
    [SerializeField] Text LevelText;

    [SerializeField] Text Colons;
    [SerializeField] Text Colons2;

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

    [Header("VFX")]
    [SerializeField] GameObject Confetti;

    [Header("Ending cubes")]
    [SerializeField] GameObject TwoByTwoRGBCube;

    [SerializeField] GameObject FinalCube;

    [SerializeField] GameObject Grey3x3Perfect;
    [SerializeField] GameObject Grey4x4Perfect;

    [Header("Stars")]
    [SerializeField] GameObject StarParentRotation;

    [SerializeField] GameObject Star1Filled;

    [SerializeField] GameObject Star2Unfilled;
    [SerializeField] GameObject Star2Filled;

    [SerializeField] GameObject Star3Unfilled;
    [SerializeField] GameObject Star3Filled;

    [SerializeField] GameObject FinalStar;
    [SerializeField] GameObject OneStarFilled;
    [SerializeField] GameObject TwoStarFilled;

    [Header("Loading Screen")]
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject LoadingFiller;

    [Header("Main Menu")]
    [SerializeField] GameObject MainMenu;

    [Header("Buttons")]
    [SerializeField] GameObject NextLevelBtn;

    [Header("SpriteChanger")]
    [SerializeField] GameObject BackgroundHyperloop;

    TimeSpan timePlaying;
    bool timerGoing;
    float elapsedTime;
    string timePlaystr;
    string timePassed;

    int clicks;

    #region public functions

    #region UpdateFields
    public void UpdateScore(string s)
    {
        ScoreText.text = "SCORE : " + s;
    } 
    public void UpdateClicks(string c)
    {
        clicks = int.Parse(c) - 1;
        ClicksText.text = "CLICKS : " + clicks;
    } 
    public void UpdateTime(string t)
    {
        TimeText.text = "TIME : " + t;
    }
    #endregion
    private void Start()
    {
        //elapsedTime = 0f;
        Invoke("StartTimer", 4f);
    }
    public void StartWinScreen()
    {
        FindObjectOfType<SoundHandler>().CongratulationsSound();

        //Invoke("DisplayCongratulationsScreen", 4f);
        Invoke("EnableTime", 1.5f);
        Invoke("EnableClicks", 2.5f);
        Invoke("EnableScore", 3.5f);
    }
    public void EnableLevelTwoWin()
    {
        TwoByTwoRGBCube.SetActive(true);
        FindObjectOfType<DisableAllGameObjects>().DisableObejcts();
        FindObjectOfType<DisableAllGameObjects>().DisableLevel();

        StartWinScreen();
    }
    #region Display Functions
    void DisplayCongratulationsScreen()
    {
        CongratulationsScreen.SetActive(true);
    }
    public void EnableScore()
    {
        Invoke("DisplayScore", 0.33f);
        WhiteScreen2.SetActive(false);
        WhiteScreen3.SetActive(true);
        if (PlayerPrefs.GetInt(PrefsHandler.stars) == 3)
        {
            Star3Filled.SetActive(true);
        }
        else
        {
            Star3Unfilled.SetActive(true);
        }

        Invoke("DisableOldStars", 1f);

        Invoke("EnableAllButtons", 0.5f);
        Invoke("DisableAllWhiteScreens", 0.5f);
        Invoke("DisableGamePlayButtons", 0.5f);
    }
    void DisableOldStars()
    {
        if (PlayerPrefs.GetInt(PrefsHandler.stars) == 3)
        {
            FinalStar.SetActive(true);

            Star1Filled.SetActive(false);
            Star2Filled.SetActive(false);
            Star2Unfilled.SetActive(false);
            Star3Filled.SetActive(false);
            Star3Unfilled.SetActive(false);
        } 
        else if (PlayerPrefs.GetInt(PrefsHandler.stars) == 2)
        {
            TwoStarFilled.SetActive(true);

            Star1Filled.SetActive(false);
            Star2Filled.SetActive(false);
            Star2Unfilled.SetActive(false);
            Star3Filled.SetActive(false);
            //Star3Unfilled.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(PrefsHandler.stars) == 1)
        {
            OneStarFilled.SetActive(true);

            Star1Filled.SetActive(false);
            Star2Filled.SetActive(false);
            //Star2Unfilled.SetActive(false);
            Star3Filled.SetActive(false);
            //Star3Unfilled.SetActive(false);
        }
    }
    void DisplayScore()
    {
        ScoreText.gameObject.SetActive(true);
    }
    public void EnableClicks()
    {
        Invoke("DisplayClick", 0.33f);
        WhiteScreen1.SetActive(false);
        WhiteScreen2.SetActive(true);

        if (PlayerPrefs.GetInt(PrefsHandler.stars) >= 2)
        {
            Star2Filled.SetActive(true);
        }
        else
        {
            Star2Unfilled.SetActive(true);
        }
    }
    void DisplayClick()
    {
        ClicksText.gameObject.SetActive(true);
    }
    public void EnableTime()
    {
        Invoke("DisplayTime", 0.33f);
        WhiteScreen1.SetActive(true);
        Star1Filled.SetActive(true);
    }
    void DisplayTime()
    {
        TimeText.gameObject.SetActive(true);
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

        if (PlayerPrefs.GetInt(PrefsHandler.stars) == 3)
        {
            Invoke("InstantiateConfetti", 0.6f);
        }
        FinalCube.GetComponent<SpriteChanging>().StartRotation();
    }

    private void InstantiateConfetti()
    {
        GameObject g = Instantiate(Confetti);
        g.transform.position = new Vector3(0, 0, 0);

        CongratulationsScreen.SetActive(true);
    }

    void DisableGamePlayButtons()
    {
        BackButton.gameObject.SetActive(false);
        SettingButton.gameObject.SetActive(false);

        FindObjectOfType<SoundHandler>().CongratulationsSound();
    }
    #endregion
    public void DisableEndingUI()
    {
        ScoreText.gameObject.SetActive(false);
        ClicksText.gameObject.SetActive(false);
        TimeText.gameObject.SetActive(false);

        NextLevel.gameObject.SetActive(false);
        Restart.gameObject.SetActive(false);
        LevevlSelection.gameObject.SetActive(false);

        //CongratulationsScreen.gameObject.SetActive(false);
    }
    public void DisableEndingUI(int i)
    {
        Invoke("DisableEndingUI", i);
    }
    #endregion

    public void StartNextButtonAnimation()
    {
        NextLevel.gameObject.GetComponent<Animator>().SetTrigger("Move");
        Restart.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        LevevlSelection.gameObject.GetComponent<Animator>().SetTrigger("Fade");
       
        SecondsText.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        MilliText.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        MinsText.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        TimeText.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        Colons.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        Colons2.gameObject.GetComponent<Animator>().SetTrigger("Fade");

        CongratulationsScreen.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        ScoreText.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        ClicksText.gameObject.GetComponent<Animator>().SetTrigger("Fade");
        LevelText.gameObject.GetComponent<Animator>().SetTrigger("Fade");
    }
    public void StartNextButtonAnimation(int i)
    {
        Invoke("StartNextButtonAnimation", i);
    }
    public void StartResizingAnimation()
    {
        if(FindObjectOfType<LevelHandler>().Galaxy == 1)
        {
            Grey3x3Perfect.GetComponent<Animator>().SetTrigger("Resizing");
            Invoke("Disable3x3Cube", 0.75f);
        }
        else if(FindObjectOfType<LevelHandler>().Galaxy == 2)
        {
            Grey4x4Perfect.GetComponent<Animator>().SetTrigger("Resizing");
            Invoke("Disable4x4Cube", 0.75f);
        }
    }
    public void Enable3x3Cube(bool b)
    {
        Grey3x3Perfect.SetActive(b);
    }
    public void Enable4x4Cube(bool b)
    {
        Grey4x4Perfect.SetActive(b);
    }
    void Disable3x3Cube()
    {
        Grey3x3Perfect.SetActive(false);
    }
    void Disable4x4Cube()
    {
        Grey4x4Perfect.SetActive(false);
    }
    public void MakeStarsTransparent()
    {
        Star1Filled.GetComponent<Animator>().SetTrigger("Transparent");
        Star2Unfilled.GetComponent<Animator>().SetTrigger("Transparent");
        Star3Unfilled.GetComponent<Animator>().SetTrigger("Transparent");
        FinalStar.GetComponent<Animator>().SetTrigger("Transparent");
    }
    public void CalculateStars(int minClicks)
    {
        if (clicks <= minClicks)
            PlayerPrefs.SetInt(PrefsHandler.stars, 3);
       
        else if (clicks <= (minClicks * 2))
            PlayerPrefs.SetInt(PrefsHandler.stars, 2);
        
        else
            PlayerPrefs.SetInt(PrefsHandler.stars, 1);

        Debug.Log("stars: " + PlayerPrefs.GetInt(PrefsHandler.stars));
    }
    public void StartTimer()
    {
        timerGoing = true;
        TimeText.gameObject.transform.localPosition = new Vector3(-180, -636, 0);
        TimeText.gameObject.SetActive(true);
        StartCoroutine(UpdateTimer());
    }
    public void StopTimer()
    {
        timerGoing = false;
        TimeText.gameObject.transform.localPosition = new Vector3(-180, -432, 0);
        FindObjectOfType<ScoreHandler>().SetTime(int.Parse(MinsText.text), int.Parse(SecondsText.text), int.Parse(MilliText.text));
    }
    IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            //timePassed = timePlaying.ToString("mm':'ss'.'ff");
            MilliText.text = timePlaying.ToString("ff");
            SecondsText.text = timePlaying.ToString("ss");
            MinsText.text = timePlaying.ToString("mm");
            //timePlaystr = "Time: " + timePassed;
            //TimeText.text = timePlaystr;
            yield return null;
        }
        TimeText.gameObject.SetActive(false);
    }
    public void EnableMainMenu()
    {
        MainMenu.SetActive(true);
    }
    #region Loading Menu
    public void EnableLoadingScreen()
    {
        LoadingScreen.SetActive(true);

        LoadingFiller.SetActive(true);
        LoadingFiller.GetComponent<Animator>().SetTrigger("Fill");
    }
    public void DisableLoadingScreen()
    {
        LoadingScreen.SetActive(false);

        LoadingFiller.SetActive(false);
        LoadingFiller.GetComponent<Animator>().SetTrigger("Reset");
    }
    #endregion

    #region Reset after level change
    public void ResetLevelChangeUI()
    {
        ResetStarsRotation();
        ResetBackgroundHyperloop();

        EnableBackBtnInGameplay();
        EnableSettingsBtnInGameplay();
        EnableRestartBtnInGameplay();
        EnableLevelTextInGameplay();
        ResetPerfectCube();
    }
    void ResetBackgroundHyperloop()
    {
        BackgroundHyperloop.GetComponent<SpriteChanging>().ResetTheCubeToTheFirstSprite();
    }
    void ResetPerfectCube()
    {
        FinalCube.GetComponent<SpriteChanging>().ResetToFirstSpriteRotation();
    }
    void ResetStarsRotation()
    {
        StarParentRotation.GetComponent<RotationHandler>().StopRotationInstantly();
        StarParentRotation.GetComponent<RotationHandler>().ResetRotation();
    }
    void EnableBackBtnInGameplay()
    {
        BackButton.gameObject.SetActive(true);
    }
    void EnableSettingsBtnInGameplay()
    {
        SettingButton.gameObject.SetActive(true);
    }
    void EnableRestartBtnInGameplay()
    {
        Restart.gameObject.SetActive(true);
    }
    void EnableLevelTextInGameplay()
    {
        LevelText.gameObject.SetActive(true);
    }
    #endregion
}
