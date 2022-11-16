using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    public Text text;
    public TextMeshProUGUI textMeshPro;
    
    private void Start()
    {
        StartBlinking();
    }
    
    IEnumerator Blink()
    {
        while (true)
        {
            switch (text.color.a.ToString())
            {
                case "0":
                    if(text)
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    if(textMeshPro)
                    textMeshPro.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    yield return new WaitForSeconds(0.4f);
                    break;
                case "1":
                    if (text)
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    if (textMeshPro)
                    textMeshPro.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    yield return new WaitForSeconds(0.4f);
                    break;
            }
        }
    }
    void StartBlinking()
    {
        //StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
