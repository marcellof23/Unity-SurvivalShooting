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
    // scoreManager.AddScore(new Score("eer", 6));
    // scoreManager.AddScore(new Score("eran", 10));
    // scoreManager.AddScore(new Score("asem", 15));
    Debug.Log(scoreManager.GetHighScores().Length.ToString());
    var scores = scoreManager.GetHighScores();

    for (int i = 0; i < scores.Length; i++)
    {
      var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
      row.rank.text = (i + 1).ToString();
      row.name.text = scores[i].getName();
      row.score.text = scores[i].getScore().ToString();
    }
  }
}
