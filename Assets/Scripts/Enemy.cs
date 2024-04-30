using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public Animator anim;
    private bool enemyDied;

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
}
