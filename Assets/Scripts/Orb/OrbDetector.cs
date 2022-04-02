using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDetector : MonoBehaviour
{

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            print("NABRAK ORB");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            print("KELUAR ORB");
        }
    }
}
