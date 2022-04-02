using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDetector : MonoBehaviour
{

    GameObject player;
    PlayerAttributes playerAttributes;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttributes = player.GetComponent<PlayerAttributes>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            Consume();
        }

    }

    private void Consume()
    {
        if (gameObject.tag == "PowerOrb")
        {
            playerAttributes.IncreaseAttackModifier();
        }
        if (gameObject.tag == "AgilityOrb")
        {
            playerAttributes.IncreaseSpeedModifier();
        }
        if (gameObject.tag == "HealthOrb")
        {
            playerAttributes.Heal();
        }
        Destroy(gameObject);
    }
}
