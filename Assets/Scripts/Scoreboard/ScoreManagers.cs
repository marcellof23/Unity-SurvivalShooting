using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManagers : MonoBehaviour
{

  public ScoreData sd;
  // Start is called before the first frame update
  void Awake()
  {
    var json = PlayerPrefs.GetString("scores_zen", "{ \"scores\" : []}");
    Debug.Log(json);

    sd = JsonUtility.FromJson<ScoreData>(json);
  }


  public Score[] GetHighScores()
  {
    return sd.scores.OrderByDescending(x => x.score).ToArray();
  }

  public void AddScore(Score score)
  {
    sd.scores.Add(score);
  }


   private void OnDestroy()
   {
     SaveScore();
   }

  public void SaveScore()
  {
    var json = JsonUtility.ToJson(sd);
    PlayerPrefs.SetString("scores_zen", json);
  }
}
