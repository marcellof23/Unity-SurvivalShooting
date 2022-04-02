using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    WaveModeManager waveManager;
    bool isDead;
    bool isSinking;
    bool isWaveMode;


    void Awake ()
    {
        //Get all references
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        waveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveModeManager>();

        isWaveMode = waveManager != null;

        //Set current health
        currentHealth = startingHealth;
    }


    void Update ()
    {
        //Cek jika sinking
        if (isSinking)
        {
            //Memindahkan object ke bawah
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    //Function to give damage to enemy
    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        //Cek jika enemy dead
        if (isDead)
            return;

        //Play enemy hurt audio
        enemyAudio.Play();

        //Kurangi health
        currentHealth -= amount;

        //Ganti posisi partikel
        hitParticles.transform.position = hitPoint;

        //Play particle system
        hitParticles.Play();

        //Dead jika health <= 0
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    public virtual void Death()
    {
        //Set isDead
        isDead = true;

        //Set CapCollider to trigger
        capsuleCollider.isTrigger = true;

        //Trigger to play animation dead
        anim.SetTrigger("Dead");

        //Play enemy death audio
        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        if(isWaveMode)
        {
            waveManager.enemiesKilled++;
            print("Enemies Killed : " + waveManager.enemiesKilled);
            print("Total Enemy : " + waveManager.totalEnemy);
            if (waveManager.enemiesKilled == waveManager.totalEnemy)
            {
                waveManager.NextWave();
            }
        }
    }


    public void StartSinking ()
    {
        //Disable nav mesh component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        
        //Set rigidBody ke kinematic
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        if(isWaveMode)
        {
            WaveModeScoreManager.score += scoreValue;
        }
        Destroy (gameObject, 2f);
    }
}
