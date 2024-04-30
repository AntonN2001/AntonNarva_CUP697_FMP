using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SoulSystem playerSouls = other.GetComponent<SoulSystem>();
        if (other.tag == "Player")
        {
            if (playerSouls != null)
            {
                playerSouls.SoulCollected();
                Destroy(gameObject);
            }
        }

    }
}
