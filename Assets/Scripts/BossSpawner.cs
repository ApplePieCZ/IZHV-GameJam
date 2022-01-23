using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform spawner;
    
    public void SpawnBoss()
    {
        Instantiate(enemyPrefab, spawner.position, spawner.rotation);
    }
}
