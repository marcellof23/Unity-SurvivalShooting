using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

  public GameObject ButtonDiagonalUpgrade;
  public GameObject ButtonFasterUpgrade;
  // Start is called before the first frame update

  void Awake()
  {
    ShowButtonUpgrade();
    ShowButtonFaster();
  }
  public void ShowButtonUpgrade()
  {
    if (ButtonDiagonalUpgrade.active)
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
    if (ButtonFasterUpgrade.active)
    {
      ButtonFasterUpgrade.SetActive(false);
    }
    else
    {
      ButtonFasterUpgrade.SetActive(true);
    }
  }
}
