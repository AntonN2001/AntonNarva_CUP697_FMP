using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    [SerializeField] private GameObject powerupScreen;
    [SerializeField] private GameObject powerupShield;
    public AudioClip powerupCollected;
    FirstPersonController fps;

    void Start()
    {
        fps = GetComponent<FirstPersonController>();
        powerupScreen.SetActive(false);
        powerupShield.SetActive(false);
    }


    public void PowerUpCollected()
    {
        powerupScreen.SetActive(true);
        powerupShield.SetActive(true);
        fps.walkingSpeed = 30f;
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(powerupCollected);
        StartCoroutine(PowerUpCooldown());
    }

    IEnumerator PowerUpCooldown()
    {
        
        yield return new WaitForSeconds(10);
        powerupScreen.SetActive(false);
        powerupShield.SetActive(false);
        fps.walkingSpeed = 4f;
    }
}
