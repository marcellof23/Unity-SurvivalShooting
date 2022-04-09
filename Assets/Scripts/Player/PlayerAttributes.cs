using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class PlayerAttributes : MonoBehaviour
{

  public ScoreManagers scoreManagers;

  public WaveModeManager waveModeManager;

  public WaveModeScoreManager waveModeScoreManager;

  public ScoreWaveManagers scoreWaveManagers;
  public TimerManager timerManager;
  public int currentHealth;

  public static int startingHealth = 100;
  public static float maxHealthModifier = 2F;
  public static float maxShootingPowerModifier = 2F;
  public static float maxSpeedModifier = 2F;

  public float currentHealthModifier;
  public float currentShootingPowerModifier;
  public float currentSpeedModifier;

  public Slider healthSlider;
  public Image damageImage;
  public AudioClip deathClip;
  public float flashSpeed = 5f;
  public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


  Animator anim;
  AudioSource playerAudio;
  PlayerMovement playerMovement;
  PlayerShooting playerShooting;
  bool isDead;
  bool damaged;


  void Awake()
  {
    // PlayerPrefs.DeleteKey("scores_zen");
    anim = GetComponent<Animator>();
    playerAudio = GetComponent<AudioSource>();
    playerMovement = GetComponent<PlayerMovement>();

    playerShooting = GetComponentInChildren<PlayerShooting>();

    currentHealthModifier = 1F;
    currentShootingPowerModifier = 1F;
    currentSpeedModifier = 1F;

    currentHealth = startingHealth;
  }


  void Update()
  {
    healthSlider.maxValue = startingHealth * currentHealthModifier;
    if (damaged)
    {
      damageImage.color = flashColour;
    }
    else
    {
      damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    }

    damaged = false;
  }


  public void TakeDamage(int amount)
  {
    damaged = true;

    currentHealth -= amount;

    healthSlider.value = currentHealth;

    playerAudio.Play();

    if (currentHealth <= 0 && !isDead)
    {
      Death();
    }
  }

  public void IncreaseAttackModifier()
  {
    currentShootingPowerModifier = (float)System.Math.Min(currentShootingPowerModifier + 0.05, maxShootingPowerModifier);
  }

  public void IncreaseSpeedModifier()
  {
    currentSpeedModifier = (float)System.Math.Min(currentSpeedModifier + 0.05, maxSpeedModifier);
  }

  public void Heal()
  {
    currentHealth = (int)System.Math.Min(currentHealth + 20, startingHealth * currentHealthModifier);
    healthSlider.value = currentHealth;
  }


  void Death()
  {
    isDead = true;
    var playerName = PlayerPrefs.GetString("name");

    Scene scene = SceneManager.GetActiveScene();
    if (scene.name == "Zen_Mode")
    {
      PlayerPrefs.SetInt("zen_time", (int)TimerManager.survivalTime);

      Score playerScore = new Score(playerName, (int)TimerManager.survivalTime);
      scoreManagers.AddScore(playerScore);

      var json = JsonUtility.ToJson(scoreManagers.sd);
      PlayerPrefs.SetString("scores_zen", json);

      SceneManager.LoadScene("Game_Over_Zen");
    }
    else if (scene.name == "Wave_Mode")
    {
      PlayerPrefs.SetInt("wave_count", waveModeManager.waveNumber);
      PlayerPrefs.SetInt("wave_score", WaveModeScoreManager.score);

      ScoreWave playerScore = new ScoreWave(playerName, waveModeManager.waveNumber, WaveModeScoreManager.score);
      scoreWaveManagers.AddScore(playerScore);

      var json = JsonUtility.ToJson(scoreWaveManagers.sd);
      PlayerPrefs.SetString("scores_wave", json);

      SceneManager.LoadScene("Game_Over_Wave");
    }

    playerShooting.DisableEffects();

    anim.SetTrigger("Die");

    playerAudio.clip = deathClip;
    playerAudio.Play();

    playerMovement.enabled = false;
    playerShooting.enabled = false;
  }

  public void RestartLevel()
  {
    SceneManager.LoadScene(0);
  }
}
