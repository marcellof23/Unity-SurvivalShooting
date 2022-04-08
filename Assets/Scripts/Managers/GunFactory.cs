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

    int cnt = 0;
    Transform t = player.transform;

    foreach (Transform tr in t)
    {
      if (tr.tag == "GunBarrelEnd")
      {
        tr.rotation = mainGun.transform.rotation;
        if (cnt == 1)
        {
          tr.rotation *= Quaternion.Euler(0, -20.0f, 0);
        }
        else if (cnt == 2)
        {
          tr.rotation *= Quaternion.Euler(0, +20.0f, 0);
        }
        else if (cnt == 3)
        {
          tr.rotation *= Quaternion.Euler(0, -40.0f, 0);
        }
        else if (cnt == 4)
        {
          tr.rotation *= Quaternion.Euler(0, +40.0f, 0);
        }
        cnt += 1;
      }
    }
    return gunBarrelEnd;
  }
}
