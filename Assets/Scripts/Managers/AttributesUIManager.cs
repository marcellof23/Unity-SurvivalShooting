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
        if(playerAttributes.currentHealthModifier >= PlayerAttributes.maxHealthModifier)
        {
            health.text = playerAttributes.currentHealthModifier + "x (MAX)";
        }
        else
        {
            health.text = playerAttributes.currentHealthModifier + "x";
        }

        if (playerAttributes.currentShootingPowerModifier >= PlayerAttributes.maxShootingPowerModifier)
        {
            attack.text = playerAttributes.currentShootingPowerModifier + "x (MAX)";
        }
        else
        {
            attack.text = playerAttributes.currentShootingPowerModifier + "x";
        }

        if (playerAttributes.currentSpeedModifier >= PlayerAttributes.maxSpeedModifier)
        {
            speed.text = playerAttributes.currentSpeedModifier + "x (MAX)";
        }
        else
        {
            speed.text = playerAttributes.currentSpeedModifier + "x";
        }
    }
}
