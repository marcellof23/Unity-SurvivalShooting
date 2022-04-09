using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreWaveUI : MonoBehaviour
{
  public RowWaveUI rowWaveUi;
  public ScoreWaveManagers scoreWaveManager;

  void Start()
  {
    var scores = scoreWaveManager.GetHighScores();

    for (int i = 0; i < Math.Min(6, scores.Length); i++)
    {
      var row = Instantiate(rowWaveUi, transform).GetComponent<RowWaveUI>();
      row.rank.text = (i + 1).ToString();
      row.name.text = scores[i].getName();
      row.wave.text = scores[i].getWave().ToString();
      row.score.text = scores[i].getScore().ToString();
    }
  }
}
