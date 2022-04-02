using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerAttributes playerAttributes;
    EnemyHealth enemyHealth;
 
    bool playerInRange;
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

    void isShootable()
    {
        Vector3 distance = (transform.position - player.transform.position);
        float distanceFrom = distance.magnitude;
        distance /= distanceFrom;
        if(distanceFrom < 15)
        {
            playerInRange = true;
        } else
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        isShootable();
        timer += Time.deltaTime;

        transform.LookAt(player.transform);

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            anim.SetBool("IsShooting", true);
            Attack();
        } else
        {
            anim.SetBool("IsShooting", false);
        }

        //Meng-trigger player death
        if (playerAttributes.currentHealth <= 0)
        {
            anim.SetBool("IsShooting", false);
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        //Reset timer
        timer = 0f;

        //Give damage to player
        //if (playerAttributes.currentHealth > 0)
        //{
          //  playerAttributes.TakeDamage(attackDamage);
       //}
    }
}
