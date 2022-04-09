using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

  public GameObject ButtonDiagonalUpgrade;
  public GameObject ButtonFasterUpgrade;

  public GameObject ButtonRangeUpgrade;
  // Start is called before the first frame update

  void Awake()
  {
    triggerUpgradeButton();
    Scene scene = SceneManager.GetActiveScene();
    if (scene.name == "Zen_Mode")
    {
      int spawnTime = 5;
      int repeatTime = 10;
      InvokeRepeating("ShowButtonUpgrade", spawnTime, repeatTime);
      InvokeRepeating("ShowButtonFaster", spawnTime, repeatTime);
      InvokeRepeating("ShowButtonRange", spawnTime, repeatTime);
    }
  }

  public void triggerUpgradeButton()
  {
    ShowButtonUpgrade();
    ShowButtonFaster();
    ShowButtonRange();
  }
  public void ShowButtonUpgrade()
  {
    Scene scene = SceneManager.GetActiveScene();

    if (ButtonDiagonalUpgrade.activeSelf)
    {
      ButtonDiagonalUpgrade.SetActive(false);
    }
    else
    {
      ButtonDiagonalUpgrade.SetActive(true);
    }
  }

  public void ShowButtonFaster()
  {
    Scene scene = SceneManager.GetActiveScene();
    if (ButtonFasterUpgrade.activeSelf)
    {
      ButtonFasterUpgrade.SetActive(false);
    }
    else
    {
      ButtonFasterUpgrade.SetActive(true);
    }
  }

  public void ShowButtonRange()
  {
    Scene scene = SceneManager.GetActiveScene();
    if (ButtonRangeUpgrade.activeSelf)
    {
      ButtonRangeUpgrade.SetActive(false);
    }
    else
    {
      ButtonRangeUpgrade.SetActive(true);
    }
  }
}
