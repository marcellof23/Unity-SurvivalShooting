using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
  public int damagePerShot = 20;
  public float timeBetweenBullets = 0.15f;
  public float range = 15f;

  float timer;
  Ray shootRay;
  RaycastHit shootHit;
  int shootableMask;
  ParticleSystem gunParticles;
  LineRenderer gunLine;
  AudioSource gunAudio;
  Light gunLight;
  float effectsDisplayTime = 0.2f;

  public PlayerAttributes playerAttributes;

  void Awake()
  {
    //Get mask
    shootableMask = LayerMask.GetMask("Shootable");

    //Mendapatkan reference component
    gunParticles = GetComponent<ParticleSystem>();
    gunLine = GetComponent<LineRenderer>();
    gunAudio = GetComponent<AudioSource>();
    gunLight = GetComponent<Light>();
  }

  void Update()
  {
    timer += Time.deltaTime;

    if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
    {
      Shoot();
    }

    if (timer >= timeBetweenBullets * effectsDisplayTime)
    {
      DisableEffects();
    }
  }

  public void DisableEffects()
  {
    //Disable line renderer
    gunLine.enabled = false;

    //Disable light
    gunLight.enabled = false;
  }

  public void setFasterBullet(float time)
  {
    this.timeBetweenBullets -= time;
  }

  public void setLongerRange(float range)
  {
    this.range += range;
  }

  void Shoot()
  {
    timer = 0f;

    //Play audio
    gunAudio.Play();

    //Enable light
    gunLight.enabled = true;

    //Play gun particle
    gunParticles.Stop();
    gunParticles.Play();

    //Enable line renderer dan set shot position
    gunLine.enabled = true;
    gunLine.SetPosition(0, transform.position);

    //Set posisi ray shoot dan direction
    shootRay.origin = transform.position;
    shootRay.direction = transform.forward;


    //Lakukan raycast jika mendeteksi id enemy hit apapun
    if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
    {
      //Lakukan raycast hit hace component Enemyhealth
      EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

      if (enemyHealth != null)
      {
        //Beri damage ke musuh
        enemyHealth.TakeDamage((int)System.Math.Round((float)damagePerShot * playerAttributes.currentShootingPowerModifier), shootHit.point);
      }

      //Set line end position ke hit position
      gunLine.SetPosition(1, shootHit.point);
    }
    else
    {
      //Set line end position ke range from barrel
      gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
    }
  }
}
