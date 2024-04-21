using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelSequence : MonoBehaviour
{
    [SerializeField] GameObject PerfectCube;
    [SerializeField] GameObject Grey3x3Cube;
    [SerializeField] GameObject Grey4x4Cube;
    
    [SerializeField] GameObject NextLevelCube;

    [SerializeField] GameObject[] Levels;
    int currentLevelIndex;

    [SerializeField] GameObject[] Levels3x3;
    [SerializeField] GameObject[] Levels4x4;

    [SerializeField] GameObject Grey3x3Sprite;
    [SerializeField] GameObject Grey4x4Sprite;

    MovementHandler[] movementHandler;

    public void NextLevelCubesSetup()
    {
        Debug.Log("Next leve cube setup");
        if(PlayerPrefs.GetInt(PrefsHandler.currentGalaxy) == 0)
        {
            PerfectCube.SetActive(true);

            //NextLevelCube.SetActive(true);
            Debug.Log("Testing Current level before addition: " + currentLevelIndex);
            currentLevelIndex++;
            Debug.Log("Testing Current level after addition: " + currentLevelIndex);

            Levels[currentLevelIndex].SetActive(true);

            movementHandler = FindObjectsOfType<MovementHandler>();

            for (int i = 0; i < movementHandler.Length; i++)
            {
                movementHandler[i].GameStartSequence();
            }

            Invoke("DisablePerfectCube", 4f);
            Debug.Log("Next leve cube setup Galaxy 1");
        }

        else if (PlayerPrefs.GetInt(PrefsHandler.currentGalaxy) == 1)
        {
            Debug.Log("3x3 galaxy");
            Grey3x3Sprite.SetActive(true);
            Grey3x3Sprite.GetComponent<Animator>().SetTrigger("Rescale");

            Invoke("EnableNext3x3Level", 0.6f);
            Debug.Log("Next leve cube setup Galaxy 2");
        }

        else if (PlayerPrefs.GetInt(PrefsHandler.currentGalaxy) == 2)
        {
            Debug.Log("4x4 galaxy");
            Grey4x4Sprite.SetActive(true);
            Grey4x4Sprite.GetComponent<Animator>().SetTrigger("Rescale");

            Invoke("EnableNext4x4Level", 0.6f);
            Debug.Log("Next leve cube setup Galaxy 3");
        }

        if (FindObjectOfType<GamePlayUI>()) Debug.LogError("Found Rotation GamePlayUI");
        FindObjectOfType<GamePlayUI>().ResetLevelChangeUI();
    }
    void EnableNext3x3Level()
    {
        #region old
        //Grey3x3Cube.SetActive(true);
        //Grey3x3Sprite.SetActive(false);

        ////Debug.Log("Testing Level3x3 length" + levels )
        //if (PlayerPrefs.GetInt(PrefsHandler.currentLevel) + 1 > Levels3x3.Length) return;

        ////currentLevelIndex++;
        ////Levels[currentLevelIndex].SetActive(true);

        //PlayerPrefs.SetInt(PrefsHandler.currentLevel, PlayerPrefs.GetInt(PrefsHandler.currentLevel) + 1);

        //Levels3x3[PlayerPrefs.GetInt(PrefsHandler.currentLevel)].SetActive(true);
        //Debug.Log("Testing : Current level 3x3: " + PlayerPrefs.GetInt(PrefsHandler.currentLevel));

        //movementHandler = FindObjectsOfType<MovementHandler>();

        //for (int i = 0; i < movementHandler.Length; i++)
        //{
        //    movementHandler[i].GameStartSequence();
        //}
        //Invoke("Disable3x3Cube", 4f);
        #endregion old
        Grey3x3Cube.SetActive(true);
        Grey3x3Sprite.SetActive(false);

        Debug.Log("Testing Level3x3 length" + Levels3x3.Length);
        //if (PlayerPrefs.GetInt(PrefsHandler.currentLevel) + 1 > Levels3x3.Length) return;

        Debug.Log("Testing Current level before addition: " + currentLevelIndex);
        currentLevelIndex++;
        Debug.Log("Testing Current level after addition: " + currentLevelIndex);

        //PlayerPrefs.SetInt(PrefsHandler.currentLevel, currentLevelIndex);
        //PlayerPrefs.SetInt(PrefsHandler.unlockedLevelGalaxy2, currentLevelIndex);

        Levels3x3[currentLevelIndex].SetActive(true);
        Debug.Log("Testing : Current level 3x3: " + PlayerPrefs.GetInt(PrefsHandler.currentLevel));

        movementHandler = FindObjectsOfType<MovementHandler>();

        for (int i = 0; i < movementHandler.Length; i++)
        {
            movementHandler[i].GameStartSequence();
        }
        Invoke("Disable3x3Cube", 4f);
    }
    void EnableNext4x4Level()
    {
        Grey4x4Cube.SetActive(true);
        Grey4x4Sprite.SetActive(false);
        
        if (PlayerPrefs.GetInt(PrefsHandler.currentLevel) + 1 > Levels4x4.Length) return;

        //PlayerPrefs.SetInt(PrefsHandler.currentLevel, PlayerPrefs.GetInt(PrefsHandler.currentLevel) + 1);
        currentLevelIndex++;
        Levels4x4[currentLevelIndex].SetActive(true);

        movementHandler = FindObjectsOfType<MovementHandler>();

        for (int i = 0; i < movementHandler.Length; i++)
        {
            movementHandler[i].GameStartSequence();
        }
        Invoke("Disable4x4Cube", 4f);
    }
    void DisablePerfectCube() 
    {
        Debug.Log("Spread - " + PerfectCube.transform.GetChild(0).gameObject.name);
        //GetComponent<MovementHandler>().Centre();
        if (PerfectCube.transform.GetChild(0).gameObject.GetComponent<MovementHandler>()) Debug.Log("Testing - Correct: Movement handler on perfect cube found");
        PerfectCube.transform.GetChild(0).gameObject.GetComponent<MovementHandler>().Centre();
        //Set all perfect cube children images to disable
        //& thn turn them back on
        //& thn disable the perfect cube after like one second
        //so all the images are gone to centre
        DisableImagesRecursively(PerfectCube.transform, false);
        Debug.Log("Testing: PerfectCube Name: " + PerfectCube.transform.name);
        Invoke("ResetPerfectCube", 2f);
        //PerfectCube.SetActive(false);
    }
    void ResetPerfectCube()
    {
        DisableImagesRecursively(PerfectCube.transform, true);
        PerfectCube.SetActive(false);
    }

    void Disable3x3Cube()
    {
        if (Grey3x3Cube.transform.GetChild(0).gameObject.GetComponent<MovementHandler>()) Debug.Log("Testing - Correct: Movement handler on perfect cube 3x3 found");
        Grey3x3Cube.transform.GetChild(0).gameObject.GetComponent<MovementHandler>().Centre();

        DisableImagesRecursively(Grey3x3Cube.transform, false);
        Debug.Log("Testing: PerfectCube 3x3 Name: " + PerfectCube.transform.name);
        Invoke("ResetPerfectCube3x3", 2f);
        //Grey3x3Cube.SetActive(false);
    }
    void ResetPerfectCube3x3()
    {
        DisableImagesRecursively(Grey3x3Cube.transform, true);
        Grey3x3Cube.SetActive(false);
    }
    void Disable4x4Cube()
    {
        //   Grey4x4Cube.SetActive(false);

        if (Grey4x4Cube.transform.GetChild(0).gameObject.GetComponent<MovementHandler>()) Debug.Log("Testing - Correct: Movement handler on perfect cube 3x3 found");
        Grey4x4Cube.transform.GetChild(0).gameObject.GetComponent<MovementHandler>().Centre();

        DisableImagesRecursively(Grey4x4Cube.transform, false);
        Debug.Log("Testing: PerfectCube 3x3 Name: " + PerfectCube.transform.name);
        Invoke("ResetPrefectCube4x4", 2f);
    }

    void ResetPrefectCube4x4()
    {
        DisableImagesRecursively(Grey4x4Cube.transform, true);
        Grey4x4Cube.SetActive(false);
    }
    public void CurrentLevelIndex(int i)
    {
        currentLevelIndex = i;
        Debug.Log("Testing currentLevelIndex - Set to: " + i);
    }
    public void DisableAllLevels()
    {
        for (int i = 0; i < Levels4x4.Length - 1; i++)
        {
            Levels4x4[i].SetActive(false);
        }
        for (int i = 0; i < Levels3x3.Length - 1; i++)
        {
            Levels3x3[i].SetActive(false);
        }
        for (int i = 0; i < Levels.Length - 1; i++)
        {
            Levels[i].SetActive(false);
        }
    }

    void DisableImagesRecursively(Transform parent, bool b)
    {
        foreach (Transform child in parent)
        {
            // Check if the child has an Image component
            Image imageComponent = child.GetComponent<Image>();
            if (imageComponent != null)
            {
                // Disable the Image component
                imageComponent.enabled = b;
            }

            // Recursively call this function for all children of the current child
            DisableImagesRecursively(child, b);
        }
    }
}
