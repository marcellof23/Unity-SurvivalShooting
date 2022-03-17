using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
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
        //Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();

        playerShooting = GetComponentInChildren<PlayerShooting>();

        currentHealth = startingHealth;
    }


    void Update()
    {
        //Jika terkena damage
        if (damaged)
        {
            //Merubah warna gambar menjadi value flashcolour
            damageImage.color = flashColour;
        }
        else
        {
            //Fade out damage image
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //Set damaged to false
        damaged = false;
    }


    //Fungsi untuk mendapat damage
    public void TakeDamage(int amount)
    {
        damaged = true;

        //Mengurangi health
        currentHealth -= amount;

        //Mengupdate health slider
        healthSlider.value = currentHealth;

        //Memainkan suara ketika player terkena damage
        playerAudio.Play();

        //Mengecek apakah player sudah mati
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        //Meng-trigger animasi die
        anim.SetTrigger("Die");

        //Memainkan suara ketika mati
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void RestartLevel ()
    {
        //meload ulang scene dengan index 0 pada build setting
        SceneManager.LoadScene(0);
    }
}
