using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject inputField; 

    void Awake()
    {
        PlayerPrefs.SetString("name", "");
        inputField.SetActive(false);
    }

    public void ChangeName()
    {
        string text = inputField.GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("name", text);
        string name = PlayerPrefs.GetString("name");

        inputField.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ShowInputName()
    {
        gameObject.SetActive(false);
        inputField.SetActive(true);
    }

    public void PlayWef()
    {
        SceneManager.LoadScene("Wave_Mode");
    }

    public void PlayZen()
    {
        SceneManager.LoadScene("Zen_Mode");
    }

    public void OpenLeaderBoard()
    {
        SceneManager.LoadScene("Scoreboard");
    }

    public void Return()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
