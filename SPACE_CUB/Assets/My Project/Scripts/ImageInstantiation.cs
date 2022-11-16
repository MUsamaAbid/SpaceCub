using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageInstantiation : MonoBehaviour
{
    [SerializeField] GameObject emptyImage;
    [SerializeField] GameObject cube;

    [SerializeField] GameObject Blue;
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Green;

    [SerializeField] GameObject FinalCube;
    [SerializeField] GameObject Effects;

    [SerializeField] GameObject Confetti;
    
    [SerializeField] DisableAllGameObjects DisableCubes;

    [SerializeField] float intervalBetweenSpreadAndCollapse;

    public void CubePressed()
    {
        //emptyImage.GetComponent<Image>().sprite = cube.GetComponent<Image>().sprite;

        //cube.GetComponent<Image>().enabled = false;

        //emptyImage.SetActive(true);

        //RearrangeCubes();
    }
    public void RearrangeCubes()
    {
        ImageReposition[] images = FindObjectsOfType<ImageReposition>();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].Colors(Blue, Red, Green, FinalCube, Confetti, Effects, intervalBetweenSpreadAndCollapse, DisableCubes);
            images[i].StartMoving();
        }
    }
}
