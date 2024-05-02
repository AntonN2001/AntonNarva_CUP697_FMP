using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bossUI;
    [SerializeField] private GameObject EndPickup;
    [SerializeField] private float projectileTimer = 10;
    private float projectileTime;
    public GameObject enemyProjectile;
    public Transform spawnPoint;
    public float enemyProjectileSpeed;
    public NavMeshAgent enemy;
    public Transform player;

    public AudioClip[] sounds;
    private AudioSource source;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //find player
        enemy = GetComponent<NavMeshAgent>();
        EndPickup.SetActive(false);
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        HealthSystem healthSystem = GetComponent<HealthSystem>();

        BossUI.healthValue = healthSystem.currentHealth;
        if(healthSystem.currentHealth <= 0)
        {
            bossUI.SetActive(false);
            EndPickup.SetActive(true);
            Destroy(gameObject);
        }

        enemy.destination = player.position;
        ShootAtPlayer();

        //if(Input.GetKeyDown(KeyCode.S))
        //{
        //    source.clip = sounds[Random.Range(0, sounds.Length)];
        //    source.Play();
        //}
    }

    void ShootAtPlayer()
    {
        projectileTime -= Time.deltaTime;
        if (projectileTime > 0) return;

        projectileTime = projectileTimer;

        GameObject projectileObj = Instantiate(enemyProjectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody projectileRig = projectileObj.GetComponent<Rigidbody>();
        projectileRig.AddForce(projectileRig.transform.forward * enemyProjectileSpeed);
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.Play();
        Destroy(projectileObj, 5f);
    }
}
