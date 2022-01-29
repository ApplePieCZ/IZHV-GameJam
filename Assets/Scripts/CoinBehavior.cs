// Script for coin collision
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    private float speed = 8f;
    
    private Transform target;
    
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        var distance = target.position - transform.position;
        if (distance.magnitude > 2f) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is "Despawner2" or "Player") Destroy(gameObject);
    }
}
