using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSpawner : MonoBehaviour
{
    public bool spawn;

    public GameObject enemyPrefab;

    public Transform[] spawner;

    public float spawnTime = 5.0f;

    public float elapsedTime;

    
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
