using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject[] Intro;
    [SerializeField] float time;

    [SerializeField] GameObject[] BigBangVideo;

    [SerializeField] GameObject BigBang;

    [SerializeField] GameObject[] PostBigBang;

    [SerializeField] GameObject SkipButton;

    [SerializeField] GameObject MainMenu;

    [SerializeField] GameObject StartScreen;

    [SerializeField] GameObject EndingBackground;
    [SerializeField] GameObject EndingCube;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip IntroClip;

    Coroutine ChangeTextCoroutine;
    Coroutine PostBigBangTextCoroutine;

    private void OnEnable()
    {
        Invoke("EnableSkipButton", 9f);
        Invoke("StartTextCoroutine", 1.5f);
        PlayIntroSound();
        Invoke("EnableEndingBackground", 115f);
        Invoke("EnableEndingCube", 119f);
        Invoke("GoToMainMenu", 121f);

        //StartBigBang();
    }
    void StartTextCoroutine()
    {
        ChangeTextCoroutine = StartCoroutine(ChangeText());
    }

    private void PlayIntroSound()
    {
        audioSource.clip = IntroClip;
        audioSource.Play();
    }

    void EnableSkipButton()
    {
        SkipButton.SetActive(true);
    }
    IEnumerator ChangeText()
    {
        for (int i = 0; i < Intro.Length - 1; i++)
        {
            Intro[i].SetActive(true);
            yield return new WaitForSeconds(time);
        }
        Intro[Intro.Length - 1].SetActive(true);
        Invoke("StartBigBang", 4.2f);
    }
    void StartBigBang()
    {
        for (int i = 0; i < BigBangVideo.Length; i++)
        {
            BigBangVideo[i].SetActive(true);
        }
        Invoke("CirculaBang", 9f);
    }

    private void CirculaBang()
    {
        BigBang.SetActive(true);
        Invoke("StartPostBigBang", 8f);
    }

    void StartPostBigBang()
    {
        PostBigBangTextCoroutine = StartCoroutine(PostBigBangText());
    }
    IEnumerator PostBigBangText()
    {
        for (int i = 0; i < PostBigBang.Length - 1; i++)
        {
            PostBigBang[i].SetActive(true);
            yield return new WaitForSeconds(time);
        }
        PostBigBang[PostBigBang.Length - 1].SetActive(true);
        //gameObject.SetActive(false);
    }
    void EnableEndingBackground()
    {
        EndingBackground.SetActive(true);
    }
    void EnableEndingCube()
    {
        EndingCube.SetActive(true);
    }
    public void GoToMainMenu()
    {
        StopCoroutine(ChangeTextCoroutine);
        StopCoroutine(PostBigBangTextCoroutine);

        ResetText();

        MainMenu.SetActive(true);
        StartScreen.SetActive(false);
        EndingBackground.SetActive(false);
        EndingCube.SetActive(false);
        gameObject.SetActive(false);
    }
    void ResetText()
    {
        foreach(var i in Intro)
        {
            i.GetComponent<Animator>().SetTrigger("Reset");
        }
        foreach (var i in Intro)
        {
            i.gameObject.SetActive(false);
        }
    }
}
