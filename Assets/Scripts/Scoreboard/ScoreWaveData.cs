using System;
using System.Collections.Generic;

[Serializable]
public class ScoreWaveData
{
  public List<ScoreWave> scoresWave;

  public ScoreWaveData()
  {
    scoresWave = new List<ScoreWave>();
  }
}