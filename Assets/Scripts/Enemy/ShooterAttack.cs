using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1.5f;
    public int attackDamage = 10;
    public float range = 100f;

    Animator anim;
    GameObject player;
    PlayerAttributes playerAttributes;
    EnemyHealth enemyHealth;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;
    float effectsDisplayTime = 0.75f;

    bool isShooting = false;
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

        //Get mask
        shootableMask = LayerMask.GetMask("Shootable");

        //Mendapatkan reference component
        gunParticles = GetComponentInChildren<ParticleSystem>();
        gunLight = GetComponentInChildren<Light>();
        gunLine = GetComponentInChildren<LineRenderer>();
    }

    void isShootable()
    {
        Vector3 distance = (transform.position - player.transform.position);
        float distanceFrom = distance.magnitude;
        if(distanceFrom < 10)
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

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0 && playerAttributes.currentHealth > 0)
        {
            anim.SetBool("IsShooting", true);
            Attack();
        } else
        {
            anim.SetBool("IsShooting", false);
        }

        if (timer >= timeBetweenAttacks * effectsDisplayTime)
        {
            DisableEffects();
        }

        //Meng-trigger player death
        if (playerAttributes.currentHealth <= 0)
        {
            anim.SetBool("IsShooting", false);
            anim.SetTrigger("PlayerDead");
        }
    }

    public void DisableEffects()
    {
        //Disable line renderer
        gunLine.enabled = false;

        //Disable light
        gunLight.enabled = false;
    }


    void Attack()
    {
        //Reset timer
        timer = 0f;

        transform.LookAt(player.transform);

        //Enable line renderer dan set shot position
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        //Set posisi ray shoot dan direction
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);


        if (!isShooting)
        {
            isShooting = true;
            Invoke("Hit", .75f);
        }
    }

    void Hit()
    {
        //Enable light
        gunLight.enabled = true;

        //Play gun particle
        gunParticles.Stop();
        gunParticles.Play();

        //Lakukan raycast jika mendeteksi id enemy hit apapun
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //Lakukan raycast hit hace component PlayerAttributes
            PlayerAttributes playerHealth = shootHit.collider.GetComponent<PlayerAttributes>();

            if (playerHealth != null)
            {
                //Beri damage ke player
                playerHealth.TakeDamage(attackDamage);
            }

            //Set line end position ke hit position
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            //Set line end position ke range from barrel
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

        //Reset isShooting
        isShooting = false;
    }
}
