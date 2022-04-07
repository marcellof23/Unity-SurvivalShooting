using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
  {
    SceneManager.LoadScene("Level_01");
  }

  public void ScoreBoard()
  {
    SceneManager.LoadScene("Scoreboard");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
  
  public void Return()
  {
    SceneManager.LoadScene("Main_Menu");
  }
}
