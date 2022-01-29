// Script for spawning enemies
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn;

    public GameObject enemyPrefab;

    public Transform[] spawner;

    public float spawnTime = 1.0f;

    private float elapsedTime;
    void FixedUpdate()
    {
        if (!spawn) return;
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= spawnTime)) return;
        var pos = spawner[0].position;
        pos.z = 0;
        
        var enemyL = Instantiate(enemyPrefab, pos, spawner[0].rotation);
        enemyL.GetComponent<EnemyBehavior>().movement = new Vector2(1f, -0.1f);

        pos = spawner[1].position;
        pos.z = 0;
        
        var enemyR = Instantiate(enemyPrefab, pos, spawner[1].rotation);
        enemyR.GetComponent<EnemyBehavior>().movement = new Vector2(-1f, -0.1f);

        elapsedTime = 0f;
    }
}
