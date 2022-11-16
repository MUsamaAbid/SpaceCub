using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool ifOnEnable;
    [SerializeField] Text text;

    private void OnEnable()
    {
        if(ifOnEnable)
            StartTimer();
    }
    public void StartTimer()
    {
        StartCoroutine("Timers");
    }
    IEnumerator Timers()
    {
        for(int i = 3; i>=0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1);
            if( i == 0)
            {
                text.text = "";
            }
        }
    }
}
