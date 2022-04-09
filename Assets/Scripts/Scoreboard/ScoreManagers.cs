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
    Debug.Log("EIII SCOREBOARD");
    for (int i = 0; i < sd.scores.ToArray().Length; i++)
    {
      // Debug.Log(JsonUtility.ToJson(sd.scores[i]));
      // Debug.Log(sd.scores[i].GetType());
      // Debug.Log(sd.scores[i].getName().ToString());
      // row.rank.text = (i + 1).ToString();
      // row.name.text = scores[i].getName();
      // row.score.text = scores[i].getScore().ToString();
    }
    Debug.Log("EIIIF SCOREBOARD");
  }


  public Score[] GetHighScores()
  {
    Debug.Log(JsonUtility.ToJson(sd));
    Debug.Log(sd.scores.ToArray().Length.ToString());
    return sd.scores.OrderByDescending(x => x.score).ToArray();
  }

  public void AddScore(Score score)
  {
    Debug.Log(JsonUtility.ToJson(score));
    Debug.Log(sd.scores.ToArray().Length.ToString());
    sd.scores.Add(score);
    for (int i = 0; i < sd.scores.ToArray().Length; i++)
    {
      Debug.Log(JsonUtility.ToJson(sd.scores[i]));
      Debug.Log(sd.scores[i].GetType());
      Debug.Log(sd.scores[i].getName().ToString());
    }
  }


  // private void OnDestroy()
  // {
  //   SaveScore();
  // }

  public void SaveScore()
  {
    var json = JsonUtility.ToJson(sd);
    PlayerPrefs.SetString("scores_zen", json);
  }
}
