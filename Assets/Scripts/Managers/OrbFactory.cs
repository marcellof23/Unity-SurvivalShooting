using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    GameObject[] orbsPrefab;

    public GameObject FactoryMethod(int tag, Vector3 position, Quaternion quaternion)
    {
        GameObject orb = Instantiate(orbsPrefab[tag], position, quaternion);
        return orb;
    }
}
