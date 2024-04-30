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
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //find player
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            other.GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);
    }
}
