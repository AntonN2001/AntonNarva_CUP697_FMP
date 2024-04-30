using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
