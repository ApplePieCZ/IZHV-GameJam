using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPassiveMasterSpawner : MonoBehaviour
{
    public bool spawn;

    public GameObject enemyPrefab;

    public Transform[] spawner;

    private float spawnTime = 0.1f;

    private int numberOfShips = 11;
    private int spawnerIndex;
    private Vector2 direction;

    private int gap = 60;
    private int gapCounter = 0;
    public float elapsedTime = 0.0f;
    void FixedUpdate()
    {
        if (!spawn) return;
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= spawnTime)) return;
        elapsedTime = 0f;

        if (numberOfShips == 0 && gapCounter++ < gap) return;
        gapCounter = 0;
        if (numberOfShips++ > 10)
        {
            spawnerIndex = UnityEngine.Random.Range(0, spawner.Length);
            direction = new Vector2(Random.value, -1);
            numberOfShips = 0;
            return;
        }
        var enemyL = Instantiate(enemyPrefab, spawner[spawnerIndex].position, spawner[spawnerIndex].rotation);
        enemyL.GetComponent<EnemyPassive>().movement = new Vector2(direction[0], direction[1]);

    }
}
