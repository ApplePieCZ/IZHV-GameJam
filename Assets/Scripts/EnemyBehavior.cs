using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rigidBody;

    public Vector2 movement = new Vector2(1f,-1f);

    public GameObject coinPrefab;

    public Transform dropPoint;
    void FixedUpdate()
    {
        if (rigidBody.position.x <= -8.4f && movement.x == -1f)
        {
            movement.x = 1f;
        }

        if (rigidBody.position.x >= 4.2f && movement.x == 1f)
        {
            movement.x = -1f;
        }
        
        if (rigidBody.position.y <= -4.4f && movement.y == -1f)
        {
            movement.y = 0;
        }

        if (rigidBody.position.y >= 4.4f && movement.y == 1f)
        {
            movement.y = 0;
        }
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Instantiate(coinPrefab, dropPoint.position, dropPoint.rotation);
    }
}