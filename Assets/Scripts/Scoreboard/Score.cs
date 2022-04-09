using System;
using UnityEngine;

[Serializable]
public class Score : MonoBehaviour
{
  public string name;
  public float score;

  public Score(string name, float score)
  {
    this.name = name;
    this.score = score;
  }

  public string getName()
  {
    return this.name;
  }

  public float getScore()
  {
    return this.score;
  }
}
