using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonModeManager : MonoBehaviour
{

  public GameObject ButtonZenMode;
  public GameObject ButtonWaveMode;

  // Start is called before the first frame update

  public void ButtonZenModeClick()
  {
    SceneManager.LoadScene("Zen_Scoreboard");
  }

  public void ButtonWaveModeClick()
  {
    SceneManager.LoadScene("Wave_Scoreboard");
  }
}
