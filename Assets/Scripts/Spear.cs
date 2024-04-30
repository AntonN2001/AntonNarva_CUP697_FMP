using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float spearLife = 3;
    public AudioClip hitSound;

    void Awake()
    {
        Destroy(gameObject, spearLife);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var healthComponent = other.GetComponent<HealthSystem>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(3);
                AudioSource ac = GetComponent<AudioSource>();
                ac.PlayOneShot(hitSound);
            }

            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
            
            Destroy(gameObject);
        }
    }
}
