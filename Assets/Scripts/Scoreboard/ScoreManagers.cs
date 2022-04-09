using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManagers : MonoBehaviour
{

  private ScoreData sd;
  // Start is called before the first frame update
  void Awake()
  {
    var json = PlayerPrefs.GetString("scores", "{}");
    if (json != null)
    {
      sd = JsonUtility.FromJson<ScoreData>(json);
    }
    //sd = new ScoreData();
  }


  public IEnumerable<Score> GetHighScores()
  {
    Debug.log(sd.ToString());
    return sd.scores.OrderByDescending(x => x.score);
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
    Debug.Log(json);
    PlayerPrefs.SetString("scores", json);
  }
}
