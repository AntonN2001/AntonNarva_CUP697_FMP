using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public Animator anim;
    private bool enemyDied;

    [SerializeField] private float projectileTimer = 5;
    private float projectileTime;
    public GameObject enemyProjectile;
    public Transform spawnPoint;
    public float enemyProjectileSpeed;

    public AudioClip tigerRoar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //find player
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>();
        //enemyDied = false;
    }

    void Update()
    {
        GetComponent<Animator>().SetTrigger("IsWalking");
        enemyDied = GetComponent<Animator>().GetBool("IsDead");

        if(enemyDied == false)
        {
            enemy.destination = player.position;
            ShootAtPlayer();
        }
        else if (enemyDied == true)
        {
            enemy.isStopped = true;
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(tigerRoar);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Animator>().SetTrigger("Attack");
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(tigerRoar);
        }
    }

    void ShootAtPlayer()
    {
        
        projectileTime -= Time.deltaTime;
        if (projectileTime > 0) return;

        projectileTime = projectileTimer;

        GameObject bulletObj = Instantiate(enemyProjectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemyProjectileSpeed);
        Destroy(bulletObj, 5f);
    }
}
