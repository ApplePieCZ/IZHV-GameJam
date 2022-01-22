using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSpawner : MonoBehaviour
{
    public bool spawn;

    public GameObject enemyPrefab;

    public Transform[] spawner;

    public float spawnTime = 5.0f;

    public float elapsedTime = 0.0f;

    
    void FixedUpdate()
    {
        if (!spawn) return;
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= spawnTime)) return;

        var enemyL = Instantiate(enemyPrefab, spawner[0].position, spawner[0].rotation);
        enemyL.GetComponent<Homing>().movement = new Vector2(1f, -0.1f);
        
        var enemyR = Instantiate(enemyPrefab, spawner[1].position, spawner[1].rotation);
        enemyR.GetComponent<Homing>().movement = new Vector2(-1f, -0.1f);

        elapsedTime = 0f;
    }
}
