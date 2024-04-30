using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioClip ammoCollected;
    WeaponController weaponController;

    void Start()
    {
        //weaponController = GetComponent<WeaponController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            weaponController = other.GetComponent<WeaponController>();

                weaponController.currentArrows++;
                AmmoUI.ammo++;
                AudioSource ac = GetComponent<AudioSource>();
                ac.PlayOneShot(ammoCollected);
                Destroy(gameObject);
        }

    }
}
