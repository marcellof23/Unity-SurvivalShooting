using System;
using UnityEngine;

public class GunFactory : MonoBehaviour, IFactory
{

  [SerializeField]
  public GameObject[] gunBarrel;

  public GameObject FactoryMethod(int tag, Vector3 position, Quaternion rotation)
  {
    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    GameObject player = players[0];

    GameObject mainGun = GameObject.Find("GunBarrelEnd");

    GameObject gunBarrelEnd = Instantiate(gunBarrel[tag], mainGun.transform.position, mainGun.transform.rotation);
    gunBarrelEnd.transform.SetParent(player.transform);

    GameObject gunBarrelEnd2 = Instantiate(gunBarrel[tag], mainGun.transform.position, mainGun.transform.rotation);
    gunBarrelEnd2.transform.SetParent(player.transform);

    int gunIdx = 0;
    Transform t = player.transform;

    float initAngle = 0f;
    foreach (Transform tr in t)
    {
      if (tr.tag == "GunBarrelEnd")
      {
        tr.rotation = mainGun.transform.rotation;
        if (gunIdx >= 1)
        {
          if (gunIdx % 2 == 1)
          {
            initAngle += 20f;
            tr.rotation *= Quaternion.Euler(0, -initAngle, 0);
          }
          else
          {
            tr.rotation *= Quaternion.Euler(0, +initAngle, 0);
          }
        }
        gunIdx += 1;
      }
    }

    return gunBarrelEnd;
  }
}
