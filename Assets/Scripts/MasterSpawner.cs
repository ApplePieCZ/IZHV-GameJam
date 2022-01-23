using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MasterSpawner : MonoBehaviour
{
    public bool spawn;
    
    public GameObject homingSpawner;

    public GameObject diagonalSpawner;

    public GameObject passiveSpawner;

    public GameObject chaosSpawner;

    public GameObject bossSpawner;

    private float elapsedTime;
    private bool chosen;
    private float spawnTime;
    private bool bossActive;

    private float x;
    void FixedUpdate()
    {
        if (!spawn)
        {
            SpawnSwitch();
            return;
        }

        if (!chosen)
        {
            x = Random.value;
            x = Mathf.Round(x * 10);
            x = 10;
            chosen = true;
            switch (x)
            {
                case 1:
                    diagonalSpawner.GetComponent<Spawner>().spawn = true;
                    spawnTime = 10f;
                    break;
                case 2:
                    diagonalSpawner.GetComponent<Spawner>().spawn = true;
                    passiveSpawner.GetComponent<EnemyPassiveMasterSpawner>().spawn = true;
                    spawnTime = 20f;
                    break;
                case 3:
                    passiveSpawner.GetComponent<EnemyPassiveMasterSpawner>().spawn = true;
                    homingSpawner.GetComponent<HomingSpawner>().spawn = true;
                    spawnTime = 25f;
                    break;
                case 4:
                    diagonalSpawner.GetComponent<Spawner>().spawn = true;
                    homingSpawner.GetComponent<HomingSpawner>().spawn = true;
                    spawnTime = 20f;
                    break;
                case 5:
                    diagonalSpawner.GetComponent<Spawner>().spawn = true;
                    passiveSpawner.GetComponent<EnemyPassiveMasterSpawner>().spawn = true;
                    spawnTime = 15f;
                    break;
                case 6:
                    diagonalSpawner.GetComponent<Spawner>().spawn = true;
                    passiveSpawner.GetComponent<EnemyPassiveMasterSpawner>().spawn = true;
                    homingSpawner.GetComponent<HomingSpawner>().spawn = true;
                    spawnTime = 30f;
                    break;
                case 7:
                    chaosSpawner.GetComponent<ChaosSpawner>().spawn = true;
                    spawnTime = 10f;
                    break;
                case 8:
                    chaosSpawner.GetComponent<ChaosSpawner>().spawn = true;
                    passiveSpawner.GetComponent<EnemyPassiveMasterSpawner>().spawn = true;
                    spawnTime = 8f;
                    break;
                case 9:
                    chaosSpawner.GetComponent<ChaosSpawner>().spawn = true;
                    homingSpawner.GetComponent<HomingSpawner>().spawn = true;
                    spawnTime = 15f;
                    break;
                case 10:
                    bossSpawner.GetComponent<BossSpawner>().SpawnBoss();
                    bossActive = true;
                    break;
                default:
                    spawnTime = 2f;
                    break;

            }
        }
        elapsedTime += Time.deltaTime;
        
        if (!(elapsedTime >= spawnTime) || bossActive) return;
        elapsedTime = 0f;
        chosen = false;
        SpawnSwitch();
    }

    void SpawnSwitch()
    {
        diagonalSpawner.GetComponent<Spawner>().spawn = false;
        passiveSpawner.GetComponent<EnemyPassiveMasterSpawner>().spawn = false;
        homingSpawner.GetComponent<HomingSpawner>().spawn = false;
        chaosSpawner.GetComponent<ChaosSpawner>().spawn = false;
    }
}
