// Script for spawner of homing enemies
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class HomingSpawner : MonoBehaviour
{
    public bool spawn;

    public GameObject enemyPrefab;

    public Transform[] spawner;

    public float spawnTime = 5.0f;

    private float elapsedTime;

    
    void FixedUpdate()
    {
        if (!spawn) return;
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= spawnTime)) return;
        
        Instantiate(enemyPrefab, spawner[0].position, spawner[0].rotation);
        Instantiate(enemyPrefab, spawner[1].position, spawner[1].rotation);

        elapsedTime = 0f;
    }
}
