using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float health = 1000f;
    private float healthMax;
        
    private float speed = 1f;

    public Transform[] firePoints;

    public GameObject coinPrefab;

    public Transform dropPoint;
    
    private Transform target;

    public GameObject bulletPrefab;
    public GameObject bulletExplodePrefab;

    private float bulletForce = 5f;

    private int barage = 150;
    
    private float homingTime;
    private float barageTime;
    private float explodeTime;
    
    public GameObject enemyPrefab;
    public Transform spawner;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
        healthMax = health;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (transform.position != target.position) return;
        barageTime += Time.deltaTime;
        if (barage != 0)
        {
            Shoot(firePoints[0]);
            Shoot(firePoints[1]);
            Shoot(firePoints[2]);
            barage -= 1;
        }
        else if (barageTime > 7f)
        {
            barageTime = 0f;
            barage = 150;
        }
        homingTime += Time.deltaTime;
        if (health <= healthMax / 100*80 && homingTime >= 2f)
        {
            Instantiate(enemyPrefab, spawner.position, spawner.rotation);
            homingTime = 0f;
        }

        explodeTime += Time.deltaTime;
        if (health <= healthMax / 100*60 && barage == 0f && explodeTime >= 3f)
        {
            ShootExplode(firePoints[0]);
            ShootExplode(firePoints[1]);
            ShootExplode(firePoints[2]);
            explodeTime = 0f;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name is not ("Bullet(Clone)" or "Despawner2" or "Player")) return;
        health -= 1f;
        print(health);
        if (health == 0f) KillBoss();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,30*Time.deltaTime);
    }

    void KillBoss()
    {
        Destroy(gameObject);
    }
    
    void Shoot(Transform firePoint)
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
    void ShootExplode(Transform firePoint)
    {
        var bullet = Instantiate(bulletExplodePrefab, firePoint.position, firePoint.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
