using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLevel : MonoBehaviour
{
    [SerializeField] GameObject OpeningAnimation;
    [SerializeField] GameObject Border;
    [SerializeField] GameObject OneStar;
    [SerializeField] GameObject TwoStar;
    [SerializeField] GameObject ThreeStar;
    [SerializeField] GameObject FullStar;

    private void OnEnable()
    {
        //EnableCurrentLevel();
    }
    public void EnableCurrentLevel()
    {
        //OpeningAnimation.SetActive(true);
        OpeningAnimation.gameObject.SetActive(true);
        OpeningAnimation.GetComponent<SpriteAnimation>().StartFirstAnimation();
        Invoke("EnableBorder", 0f);
    }
    void EnableBorder()
    {
        //OpeningAnimation.SetActive(false);
        Border.SetActive(true);
        EnableStar();
    }
    void EnableStar()
    {
        FullStar.SetActive(true);
    }
    public void CloseCurrentLevel()
    {
        OpeningAnimation.GetComponent<SpriteAnimation>().CloseAnimation();
        Border.SetActive(false);
        OpeningAnimation.gameObject.SetActive(false);
    }
}
