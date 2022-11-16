using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageReposition : MonoBehaviour
{
    [SerializeField] Vector3 spreadedPos;
    [SerializeField] Vector3 targetPos;
    Vector3 currentTarget;

    [SerializeField] float speed;
   
    float intervalBetweenSpreadandCollapse;
    
    GameObject FinalCube;
    
    public bool move;

    bool ifCentre;

    GameObject Blue, Green, Red;
    GameObject Confetti, Effects;

    GamePlayUI gamePlayUI;

    DisableAllGameObjects DisableCubes;

    private void Start()
    {
        gamePlayUI = FindObjectOfType<GamePlayUI>();

        currentTarget = spreadedPos;

        if (gameObject.tag == "empty") ifCentre = true;

        move = false;
    }

    public void StartMoving()
    {
        move = true;
    }
    public void ForCentreSprites()
    {
        if (!ifCentre) return;

        ifCentre = false;
        InstantiateColors();
    }
    public void Colors(GameObject B, GameObject R, GameObject G, GameObject finalCube, GameObject Confetti, GameObject Effects, float intervalBetweenSpreadAndCollapse, DisableAllGameObjects DisableCubes)
    {
        Blue = B;
        Green = G;
        Red = R;

        FinalCube = finalCube;

        this.Confetti = Confetti;

        this.Effects = Effects;
        Invoke("ChangeToRGB", 1.5f);

        this.intervalBetweenSpreadandCollapse = intervalBetweenSpreadAndCollapse;

        this.DisableCubes = DisableCubes;
    }

    private void ChangeToRGB()
    {
        if (this.Effects.GetComponentInParent<SpriteChanging>())
        {
            Debug.Log("Name of effects parents is : " + this.Effects.transform.parent.name);
            this.Effects.GetComponentInParent<SpriteChanging>().ChangeToRGBSprite();
        }
    }

    void InstantiateColors()
    {
        if (ifCentre) return;

        Debug.Log("Colors intantiating");

        Instantiate(Blue, transform);
        Instantiate(Green, transform);
        Instantiate(Red, transform);

        if (!FinalCube.activeSelf)
        {
            FinalCube.SetActive(true);
            Effects.SetActive(true);
            //InstantiateConfetti();

            gamePlayUI.StartWinScreen();
            DisableCubes.DisableObejcts();
            DisableCubes.DisableLevel();
            //g.transform.parent = null;
            //g.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void InstantiateConfetti()
    {
        GameObject g = Instantiate(Confetti);
        g.transform.position = new Vector3(0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (move)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentTarget, Time.deltaTime * speed);

            if (transform.localPosition == spreadedPos)
            {
                currentTarget = targetPos;
                move = false;
                Invoke("StartMoving", intervalBetweenSpreadandCollapse);
            }
            else if (transform.localPosition == targetPos)
            {
                Debug.Log("Target reached");

                InstantiateColors();
                move = false;
                CheckForTheCentreSprites();
            }
        }
    }
    void CheckForTheCentreSprites()
    {
        if(gameObject.tag != "empty")
        {
            ImageReposition[] images = FindObjectsOfType<ImageReposition>();
            for(int i = 0; i < images.Length; i++)
            {
                images[i].ForCentreSprites();
            }
        }
    }
    public void StartStartingFunction()
    {

    }
}
