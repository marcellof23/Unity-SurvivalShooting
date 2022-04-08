using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayWef()
    {
        SceneManager.LoadScene("Wave_Mode");
    }

    public void PlayZen()
    {
        SceneManager.LoadScene("Zen_Mode");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
