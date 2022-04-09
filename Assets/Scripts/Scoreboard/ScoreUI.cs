using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
  public RowUI rowUi;
  public ScoreManagers scoreManager;

  void Start()
  {
    Debug.Log(scoreManager.GetHighScores().Length.ToString());
    var scores = scoreManager.GetHighScores();

    for (int i = 0; i < Math.Min(6, scores.Length); i++)
    {
      var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
      row.rank.text = (i + 1).ToString();
      row.name.text = scores[i].getName();
      Debug.Log(scores[i].getSurvivalTime().ToString());
      row.survival_time.text = scores[i].getSurvivalTime().ToString();
    }
  }
}
