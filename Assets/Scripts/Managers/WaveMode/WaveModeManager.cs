using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveModeManager : MonoBehaviour
{

  public int waveNumber = 0;
  public int enemySpawnWeight = 0;
  public int totalEnemy = 0;
  public int enemiesKilled = 0;
  public int currentWeight = 0;
  public bool isBossWave = false;

  void Start()
  {
    StartWave();
  }

  void StartWave()
  {
    waveNumber = 1;
    enemySpawnWeight = 5;
    enemiesKilled = 0;
    totalEnemy = 0;
    currentWeight = 0;
    isBossWave = false;
  }

  public void NextWave()
  {
    waveNumber++;
    enemySpawnWeight += 2;
    enemiesKilled = 0;
    totalEnemy = 0;
    currentWeight = 0;
    isBossWave = waveNumber % 3 == 0;
  }
}
