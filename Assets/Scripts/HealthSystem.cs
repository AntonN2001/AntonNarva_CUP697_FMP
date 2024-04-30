using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject soulPrefab;
    private Vector3 objSpawnOffsetY;
    //public bool enemyIsDead;

    public Animator anim;

    public void Start()
    {
        currentHealth = maxHealth;
        //enemyIsDead = false;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            //Death
            //enemyIsDead = true;
            anim.SetBool("IsDead", true);

            StartCoroutine(DeathDelay());
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1.5f);
        objSpawnOffsetY = transform.position;
        objSpawnOffsetY.y += 1;
        Instantiate(soulPrefab, objSpawnOffsetY, Quaternion.identity);
        Destroy(gameObject);
    }

}
