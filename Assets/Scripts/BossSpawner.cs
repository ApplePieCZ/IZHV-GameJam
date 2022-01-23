// Script for boss spawner
// Author: Lukas Marek
// Date: 22.01.2022
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
