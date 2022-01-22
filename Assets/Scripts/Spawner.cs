  // Script for spawning enemies
 // Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn;

    public GameObject enemyPrefab;

    public Transform spawner;

    public float spawnTime = 1.0f;

    private float elapsedTime = 0.0f;
    void FixedUpdate()
    {
        if (!spawn) return;
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= spawnTime)) return;

        var enemyL = Instantiate(enemyPrefab, spawner.position, spawner.rotation);
        enemyL.GetComponent<EnemyBehavior>().movement = new Vector2(1f, -0.1f);

        elapsedTime = 0f;
    }
}
