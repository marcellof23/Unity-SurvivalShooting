using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

  public void DiagonalUpgradeButton()
  {
    buttonManager.triggerUpgradeButton();
    Invoke("SpawnGun", 0.0f);
  }

  public void FasterUpgradeButton()
  {
    buttonManager.triggerUpgradeButton();
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
