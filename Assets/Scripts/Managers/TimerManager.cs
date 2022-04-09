using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
  public PlayerAttributes playerAttributes;
  public static float survivalTime;

  Text text;
  float time, timeDelay;
  private void Awake()
  {
    text = GetComponent<Text>();
    survivalTime = 0;
  }

  // Update is called once per frame
  void Update()
  {
    time = time + 1f * Time.deltaTime;
    if (playerAttributes.currentHealth > 0)
    {
      time = 0f;
      timeDelay = 2f;
      survivalTime += Time.deltaTime;
      text.text = GetMinute() + ":" + GetSeconds();
    }
    else
    {
      text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
      text.text = "";
      if (time >= timeDelay)
      {
        text.text = "Survival time : " + GetMinute() + ":" + GetSeconds();
      }
    }
  }

  private string GetMinute()
  {
    int survivalTimeMinutes = (int)survivalTime / 60;
    if (survivalTimeMinutes < 10)
    {
      return "0" + survivalTimeMinutes.ToString();
    }

    return survivalTimeMinutes.ToString();
  }

  private string GetSeconds()
  {
    int survivalTimeSeconds = (int)survivalTime % 60;
    if (survivalTimeSeconds < 10)
    {
      return "0" + survivalTimeSeconds.ToString();
    }
    return survivalTimeSeconds.ToString();
  }

}
