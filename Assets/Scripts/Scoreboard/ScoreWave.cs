using System;
using UnityEngine;

[Serializable]
public class ScoreWave
{
  public string name;
  public int wave;
  public int score;

  public ScoreWave(string name, int wave, int score)
  {
    this.name = name;
    this.wave = wave;
    this.score = score;
  }

  public string getName()
  {
    return name;
  }

  public int getWave()
  {
    return wave;
  }

  public int getScore()
  {
    return score;
  }
}
