using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreWaveManagers : MonoBehaviour
{

  public ScoreWaveData sd;
  // Start is called before the first frame update
  void Awake()
  {
    var json = PlayerPrefs.GetString("scores_wave", "{ \"scores\" : []}");
    Debug.Log(json);

    sd = JsonUtility.FromJson<ScoreWaveData>(json);
  }


  public ScoreWave[] GetHighScores()
  {
    return sd.scoresWave.OrderByDescending(x => x.getWave()).ToArray();
  }

  public void AddScore(ScoreWave score)
  {
    sd.scoresWave.Add(score);
  }


  private void OnDestroy()
  {
    SaveScore();
  }

  public void SaveScore()
  {
    var json = JsonUtility.ToJson(sd);
    PlayerPrefs.SetString("scores_wave", json);
  }
}
