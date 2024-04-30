using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public Animator anim;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetComponent<Animator>().SetTrigger("IsWalking");
        enemy.destination = player.position;
    }
}
