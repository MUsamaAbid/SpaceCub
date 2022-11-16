using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TextType{
    Sound,
    Music
}
public class UpdateTextOnClick : MonoBehaviour
{
    [SerializeField] Text TextComponent;
    public TextType type;

    public void OnButtonPress()
    {
        if(type == TextType.Sound)
        {
            if (TextComponent.text == "Sound On")
            {
                TextComponent.text = "Sound Off";
            }
            else if (TextComponent.text == "Sound Off")
            {
                TextComponent.text = "Sound On";
            }
            else
            {
                TextComponent.text = "Sound On";
            }
        }
        else if (type == TextType.Music)
        {
            if (TextComponent.text == "Music On")
            {
                TextComponent.text = "Music Off";
            }
            else if (TextComponent.text == "Music Off")
            {
                TextComponent.text = "Music On";
            }
            else
            {
                TextComponent.text = "Music On";
            }
        }
    }
}
