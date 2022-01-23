// Script for homing enemy behavior
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class Homing : MonoBehaviour
{
    private float speed = 3f;
    
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
        if (other.name is not ("Bullet(Clone)" or "Despawner2" or "Player")) return;
        Destroy(gameObject);
        Instantiate(coinPrefab, dropPoint.position, dropPoint.rotation);
    }
}
