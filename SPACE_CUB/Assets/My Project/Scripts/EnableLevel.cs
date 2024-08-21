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
    public void EnableCurrentLevel(int stars)
    {
        //OpeningAnimation.SetActive(true);
        OpeningAnimation.gameObject.SetActive(true);
        OpeningAnimation.GetComponent<SpriteAnimation>().StartFirstAnimation();

        //Invoke("EnableBorder", 0f);
        EnableBorder(stars);
    }
    void EnableBorder(int stars)
    {
        //OpeningAnimation.SetActive(false);
        Border.SetActive(true);
        EnableStar(stars);
    }
    void EnableStar(int stars)
    {
        OneStar.SetActive(false);
        TwoStar.SetActive(false);
        ThreeStar.SetActive(false);
        FullStar.SetActive(false);
        if (stars == 0)
        {
            //FullStar.SetActive(true);
        }
        else if(stars == 2)
        {
            OneStar.SetActive(true);
            TwoStar.SetActive(true);
        }
        else if (stars == 1)
        {
            OneStar.SetActive(true);
        }
        else if (stars == 3)
        {
            FullStar.SetActive(true);
        }
    }
    public void CloseCurrentLevel()
    {
        OpeningAnimation.GetComponent<SpriteAnimation>().CloseAnimation();
        Border.SetActive(false);
        OpeningAnimation.gameObject.SetActive(false);
    }
}
