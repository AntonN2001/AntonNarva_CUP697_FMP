using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PowerUpSystem playerPowerup = other.GetComponent<PowerUpSystem>();
        if (other.tag == "Player")
        {
            if (playerPowerup != null)
            {
                playerPowerup.PowerUpCollected();
                Destroy(gameObject);
            }
        }

    }
}
