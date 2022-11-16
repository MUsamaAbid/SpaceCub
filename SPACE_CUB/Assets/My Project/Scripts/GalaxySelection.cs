using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GalaxySelection : MonoBehaviour
{
    [SerializeField] GameObject[] Galaxies;

    [SerializeField] GameObject BackBtn;
    [SerializeField] GameObject NextBtn;
    
    int index;

    private void Start()
    {
       
    }
    private void OnEnable()
    {
        //index = 0;
        //Galaxies[0].SetActive(true);
        //BackBtn.SetActive(false);
        //NextBtn.SetActive(true);
        index = 1;
        Galaxies[1].SetActive(true);
        BackBtn.SetActive(true);
        NextBtn.SetActive(true);
    }

    public void Back()
    {
        index--;
        if (index == 0)
        {
            BackBtn.SetActive(false);
        }

        NextBtn.SetActive(true);

        Galaxies[index + 1].SetActive(false);
        Galaxies[index].SetActive(true);
    }
    public void Next()
    {
        index++;
        if(index >= Galaxies.Length - 1)
        {
            NextBtn.SetActive(false);
        }

        BackBtn.SetActive(true);
        
        Galaxies[index - 1].SetActive(false);
        Galaxies[index].SetActive(true);
    }
}
