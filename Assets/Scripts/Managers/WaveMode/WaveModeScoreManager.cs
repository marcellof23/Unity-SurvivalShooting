using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveModeScoreManager : MonoBehaviour
{
    public static int score;
    WaveModeManager waveManager;

    Text scoreText;
    Text waveText;

    void Awake()
    {
        waveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveModeManager>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        waveText = GameObject.FindGameObjectWithTag("Wave").GetComponent<Text>();
        score = 0;
    }


    void Update()
    {
        scoreText.text = "Score: " + score;
        waveText.text = "Wave : " + waveManager.waveNumber;
    }
}
