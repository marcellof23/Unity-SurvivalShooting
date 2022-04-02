using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAttributes : MonoBehaviour
{

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
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        playerShooting = GetComponentInChildren<PlayerShooting>();

        currentHealthModifier = 1F;
        currentShootingPowerModifier = 10F;
        currentSpeedModifier = 2F;

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


    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void RestartLevel ()
    {
        SceneManager.LoadScene(0);
    }
}
