using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rigidBody;

    public Vector2 movement;

    public GameObject coinPrefab;

    public Transform dropPoint;
    
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is not "Bullet(Clone)" or "Despawner2") return;
        Destroy(gameObject);
        Instantiate(coinPrefab, dropPoint.position, dropPoint.rotation);
    }
}
