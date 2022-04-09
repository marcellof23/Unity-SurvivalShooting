using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverZen : MonoBehaviour
{
    public Text timeText;
    int time;
    void Awake()
    {
        time = PlayerPrefs.GetInt("zen_time");
        timeText.text = "Survival Time : " + GetMinute() + ":" + GetSeconds();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Zen_Mode");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    private string GetMinute()
    {
        int survivalTimeMinutes = (int)time / 60;
        if (survivalTimeMinutes < 10)
        {
            return "0" + survivalTimeMinutes.ToString();
        }

        return survivalTimeMinutes.ToString();
    }

    private string GetSeconds()
    {
        int survivalTimeSeconds = (int)time % 60;
        if (survivalTimeSeconds < 10)
        {
            return "0" + survivalTimeSeconds.ToString();
        }
        return survivalTimeSeconds.ToString();
    }
}
