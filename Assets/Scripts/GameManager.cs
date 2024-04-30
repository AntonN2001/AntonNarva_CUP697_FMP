using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentWave = 1;
    public int maxWaves = 100;
    public int enemiesInWave = 5;
    public int enemiesSpawnedInWave = 0;
    public float enemySpawnTimer = 0;
    public float intervalBetweenSpawns = 3;
    public Transform[] enemySpawnPoints;
    public GameObject skeletonEnemy;
    private bool waveEnded;
    public float waveInterval = 10;

    private void Start()
    {
        currentWave = 1;
        waveEnded = false;
        WaveUI.waveNum = currentWave;
    }

    void FixedUpdate()
    {
        if ((enemiesSpawnedInWave < enemiesInWave) && (waveEnded == false))
        {
            if (enemySpawnTimer > intervalBetweenSpawns)
            {
                SpawnEnemy();
                enemySpawnTimer = 0;
            }
            else
            {
                enemySpawnTimer += Time.deltaTime;
            }
        }
        else if(enemiesSpawnedInWave == enemiesInWave)
        {
            waveEnded = true;
            enemiesInWave = enemiesInWave * 2;
            currentWave++;
            WaveUI.waveNum++;
            StartCoroutine(WaveCooldown());
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position; //selects random spawn points from range of spawn points in array
        Instantiate(skeletonEnemy, randomSpawnPoint, Quaternion.identity);
        enemiesSpawnedInWave++;
    }

    IEnumerator WaveCooldown()
    {
        yield return new WaitForSeconds(waveInterval);
        waveEnded = false;
    }
}