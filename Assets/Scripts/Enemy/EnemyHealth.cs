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
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        //Get all references
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent <CapsuleCollider> ();

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


    void Death ()
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
    }


    public void StartSinking ()
    {
        //Disable nav mesh component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        
        //Set rigidBody ke kinematic
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
