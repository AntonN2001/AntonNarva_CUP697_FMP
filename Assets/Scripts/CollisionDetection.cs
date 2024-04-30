using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public GameObject hitParticle;
    public AudioClip hitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.isAttacking)
        {
            var healthComponent = other.GetComponent<HealthSystem>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }

            //Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(hitSound);
            Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }

    }
}
