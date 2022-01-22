// Script for enemy movement and collision
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private bool _spawn = true;
    public float speed = 5f;

    public Rigidbody2D rigidBody;

    public Vector2 movement = new Vector2(1f,-1f);

    public GameObject coinPrefab;

    public Transform dropPoint;
    void FixedUpdate()
    {
        if (rigidBody.position.x > -8.4f && rigidBody.position.x < 4.2f) _spawn = false;
        if (!_spawn && rigidBody.position.x <= -8.4f && movement.x == -1f) //Out of bounds left
        {
            movement.x = 1f;
        }

        if (!_spawn && rigidBody.position.x >= 4.2f && movement.x == 1f) //Out of bounds right
        {
            movement.x = -1f;
        }
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Bullet(Clone)") return;
        Destroy(gameObject);
        Instantiate(coinPrefab, dropPoint.position, dropPoint.rotation);
    }
}