using UnityEngine;
using System.Collections;

public class BomberAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 50;

    Animator anim;
    GameObject player;
    PlayerAttributes playerAttributes;
    EnemyHealth enemyHealth;
    bool playerInRange;
    bool isExploding = false;
    float timer;

    void Awake()
    {
        //Mencari game object dengan tag player
        player = GameObject.FindGameObjectWithTag("Player");

        //Mendapatkan komponen player health
        playerAttributes = player.GetComponent<PlayerAttributes>();

        //Mendapatkan enemy health
        enemyHealth = GetComponent<EnemyHealth>();

        //Mendapatkan komponen animator
        anim = GetComponent<Animator>();
    }

    //Callback jika ada suatu object yang masuk ke dalam trigger
    void OnTriggerEnter(Collider other)
    {
        //Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    //Callback jika ada object yang keluar dari trigger
    void OnTriggerExit(Collider other)
    {
        //Set player not in range
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            if (!isExploding)
            {
                isExploding = true;
                Invoke("Explode", 1f);
            }
        }

        //Meng-trigger player death
        if (playerAttributes.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Explode()
    {
        //Reset timer
        timer = 0f;

        Vector3 distance = (transform.position - player.transform.position);
        float distanceFrom = distance.magnitude;
        if (distanceFrom < 2)
        {
            //Give damage to player
            if (playerAttributes.currentHealth > 0)
            {
                playerAttributes.TakeDamage(attackDamage);
            }
        }
        enemyHealth.currentHealth = 0;
        enemyHealth.Death();
    }
}
