using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
  public PlayerAttributes playerAttributes;

  public ButtonManager buttonManager;
  public PlayerShooting playerShooting;
  public GameObject gunBarrelEnd;
  public float spawnTime = 0.001f;
  public float repeatTime = 10f;
  public Transform[] spawnPoints;

  public GameObject[] gunBarrel;

  [SerializeField]
  MonoBehaviour factory;
  IFactory Factory { get { return factory as IFactory; } }

  void Start()
  {
    //Mengeksekusi perintah spawn dengan interval spawnTime
    InvokeRepeating("SpawnGun", spawnTime, repeatTime);
  }


  void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      InvokeRepeating("SpawnGun", spawnTime, repeatTime);
    }
  }

  public void DiagonalUpgradeButton()
  {
    buttonManager.ShowButtonUpgrade();
    buttonManager.ShowButtonFaster();
    Invoke("SpawnGun", 0.0f);
  }

  public void FasterUpgradeButton()
  {
    buttonManager.ShowButtonUpgrade();
    buttonManager.ShowButtonFaster();
    playerShooting.setFasterBullet(0.002f);
  }

  void SpawnGun()
  {
    //Jika player mati maka tidak usah meng-spawn gun baru
    if (playerAttributes.currentHealth <= 0f)
    {
      return;
    }
    //Mendapatkan nilai random untuk spawn point gun
    int spawnPointIndex = 0;
    //Menduplikasi gun
    Factory.FactoryMethod(spawnPointIndex, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
  }
}
