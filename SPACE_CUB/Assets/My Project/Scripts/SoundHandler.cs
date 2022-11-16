using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip[] Right;
    [SerializeField] AudioClip Button;
    [SerializeField] AudioClip Wrong;
    [SerializeField] AudioClip Score;
    [SerializeField] AudioClip Countdown;
    [SerializeField] AudioClip Time;
    [SerializeField] AudioClip Clicks;
    [SerializeField] AudioClip Confetti;
    [SerializeField] AudioClip LevelFinish;
    [SerializeField] AudioClip Congratulations;

    private void Start()
    {
        //CountdownShowSound();
    }
    public void RightButtonClickSound(int i)
    {
        if (i > Right.Length - 1)
        {
            Debug.LogError("Sound can't be played");
            return;
        }
        audioSource.Stop();
        audioSource.PlayOneShot(Right[i]);
    }
    public void ButtonClickSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Button);
    }
    public void WrongClickSound()
    {
        audioSource.Stop();
        //audioSource.PlayOneShot(Wrong);
        Debug.Log("Playing sounds");
    }
    public void ScoreShowSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Score);
    }
    public void TimeShowSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Time);
    }
    public void CountdownShowSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Countdown);
    }
    public void ConfettiSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Confetti);
    }
    public void LevelFinishSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(LevelFinish);
    }
    public void CongratulationsSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Congratulations);
    }
}
