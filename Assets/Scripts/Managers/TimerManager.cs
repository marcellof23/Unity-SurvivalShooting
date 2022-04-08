using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static float survivalTime;

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        survivalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        survivalTime += Time.deltaTime;
        text.text = GetMinute() + ":" + GetSeconds();
    }

    private string GetMinute()
    {
        int survivalTimeMinutes = (int)survivalTime / 60;
        if(survivalTimeMinutes < 10)
        {
            return "0" + survivalTimeMinutes.ToString();
        }

        return survivalTimeMinutes.ToString();
    }

    private string GetSeconds()
    {
        int survivalTimeSeconds = (int)survivalTime % 60;
        if(survivalTimeSeconds < 10)
        {
            return "0" + survivalTimeSeconds.ToString();
        }
        return survivalTimeSeconds.ToString();
    }

}
