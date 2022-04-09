using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWave : MonoBehaviour
{
    public Text waveText;
    int waveCount;
    int waveScore;
    void Awake()
    {
        waveCount = PlayerPrefs.GetInt("wave_count");
        waveScore = PlayerPrefs.GetInt("wave_score");
        waveText.text = "Wave : " + waveCount + " " + "Score : " + waveScore;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Wave_Mode");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
