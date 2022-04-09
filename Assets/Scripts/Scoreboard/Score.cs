using System;
using UnityEngine;

[Serializable]
public class Score
{
  public string name;
  public int score;

  public Score(string name, int score)
  {
    this.name = name;
    this.score = score;
  }

  public string getName()
  {
    return name;
  }

  public int getScore()
  {
    return score;
  }
}
