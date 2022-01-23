// Script for passive enemies
// Author: Tomas Krsicka
// Date: 22.01.2022
using UnityEngine;

public class EnemyPassive : MonoBehaviour
{
    private float speed = 4f;

    public Rigidbody2D rigidBody;

    public Vector2 movement;

    public GameObject coinPrefab;

    public Transform dropPoint;
    void FixedUpdate()
    {
        if (rigidBody.position.x <= -8.4f && movement.x < 0) //Out of bounds left
        {
            movement.x *=-1;
        }

        if (rigidBody.position.x >= 4.2f && movement.x > 0) //Out of bounds right
        {
            movement.x *=-1;
        }
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is not  ("Bullet(Clone)" or "Despawner2")) return;
        Destroy(gameObject);
        Instantiate(coinPrefab, dropPoint.position, dropPoint.rotation);
    }
}
