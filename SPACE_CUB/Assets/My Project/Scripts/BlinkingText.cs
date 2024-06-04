using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    public Text text;
    public TextMeshProUGUI textMeshPro;

    public float blinkInterval = 1.0f; // Blink interval in seconds

    private bool isTextEnabled = true;
    private float timer = 0f;

    private void Start()
    {
        StartBlinking();

        // Check if TextMeshPro component is assigned
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component is not assigned!");
            enabled = false;
            return;
        }

        // Start the blinking coroutine
        StartCoroutine(BlinkText());
    }
    IEnumerator BlinkText()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);
            isTextEnabled = !isTextEnabled;
            textMeshPro.enabled = isTextEnabled;
        }
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
