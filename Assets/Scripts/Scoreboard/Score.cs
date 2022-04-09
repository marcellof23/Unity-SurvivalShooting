using System;
using UnityEngine;

[Serializable]
public class Score
{
  public string name;
  public int survival_time;

  public Score(string name, int survival_time)
  {
    this.name = name;
    this.survival_time = survival_time;
  }

  public string getName()
  {
    return name;
  }

  public int getSurvivalTime()
  {
    return survival_time;
  }
}
