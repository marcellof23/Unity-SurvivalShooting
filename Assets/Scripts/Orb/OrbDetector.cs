using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDetector : MonoBehaviour
{

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("NABRAK ORB");
    }

    private void OnTriggerExit(Collider other)
    {
        print("KELUAR ORB");
    }
}
