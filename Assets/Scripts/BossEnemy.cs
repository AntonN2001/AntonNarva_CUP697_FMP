using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bossUI;

    void Update()
    {
        HealthSystem healthSystem = GetComponent<HealthSystem>();

        BossUI.healthValue = healthSystem.currentHealth;
        if(healthSystem.currentHealth == 0)
        {
            bossUI.SetActive(false);
            Destroy(gameObject);
        }
    }
}
