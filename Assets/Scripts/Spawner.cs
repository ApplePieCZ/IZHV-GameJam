using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn;

    public GameObject enemyPrefab;

    public Transform spawner;

    public float spawnTime = 1.0f;

    public float elapsedTime = 0.0f;
    void FixedUpdate()
    {
        if (!spawn) return;
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= spawnTime)) return;
        
        Instantiate(enemyPrefab, spawner.position, spawner.rotation);
        elapsedTime = 0f;
    }
}
