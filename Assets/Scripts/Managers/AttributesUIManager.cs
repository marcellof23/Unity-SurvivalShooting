using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributesUIManager : MonoBehaviour
{

    public PlayerAttributes playerAttributes;

    public Text health;
    public Text attack;
    public Text speed;

    // Update is called once per frame
    void Update()
    {
        health.text = playerAttributes.currentHealthModifier + "x";
        attack.text = playerAttributes.currentShootingPowerModifier + "x";
        speed.text = playerAttributes.currentSpeedModifier + "x";
    }
}
