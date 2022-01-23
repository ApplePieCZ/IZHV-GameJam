// Script for boss movement and behavior
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    private float health = 250f;
    private static float level = 1f;
    private float healthMax;
        
    private float speed = 1f;

    public Transform[] firePoints;

    public GameObject coinPrefab;

    public Transform dropPoint;
    
    private Transform target;
    private bool inPosition;
    private bool damaged;
    private bool bossDead;

    public GameObject bulletPrefab;
    public GameObject bulletExplodePrefab;
    
    private SpriteRenderer _spriteRenderer;

    public Sprite spriteDamaged;
    public Sprite spriteDamagedMore;
    public Sprite spriteShield;
    public Sprite spriteNormal;
    public Sprite spriteDestroyed;

    private float bulletForce = 5f;

    private int barage = 150;
    
    private float homingTime;
    private float barageTime;
    private float explodeTime;
    private float ringTime;
    private float waitTime;
    
    public GameObject enemyPrefab;
    public Transform spawner;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
        level = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MasterSpawner>().levelMax;
        healthMax = health + level * 250;
        health = healthMax;
    }

    void FixedUpdate()
    {
        if (waitTime < 5f)
        {
            waitTime += Time.deltaTime;
            return;
        }
        if (!inPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position == target.position) inPosition = true;
            _spriteRenderer = gameObject.transform.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = spriteShield;
            return;
        }

        if (bossDead)
        {
            _spriteRenderer = gameObject.transform.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = spriteDestroyed;
            return;
        }

        if (!damaged)
        {
            _spriteRenderer = gameObject.transform.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = spriteNormal;
        }
        
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
        if (health <= healthMax / 100*70 && barage == 0f && explodeTime >= 3f)
        {
            ShootExplode(firePoints[0]);
            ShootExplode(firePoints[1]);
            ShootExplode(firePoints[2]);
            explodeTime = 0f;
        }

        ringTime += Time.deltaTime;
        if (health <= healthMax / 100*50 && ringTime >= 4f)
        {
            ShootRing();
            ringTime = 0f;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Despawner2") Destroy(gameObject);
        if (other.name is not ("Bullet(Clone)" or "Player")) return;
        if (transform.position != target.position) return;
        if (bossDead) return;
        health -= 1f;
        if (health <= healthMax / 100 * 20)
        {
            _spriteRenderer = gameObject.transform.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = spriteDamagedMore;
        }
        else if (health <= healthMax / 100 * 60)
        {
            _spriteRenderer = gameObject.transform.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = spriteDamaged;
            damaged = true;
        }
        if (health == 0f) KillBoss();

    }

    // Update is called once per frame
    void Update()
    {
        if (health < healthMax / 100 * 25 && !bossDead)
        {
            transform.Rotate (0,0,45*Time.deltaTime);
            return;
        }
        if (bossDead)
        {
            transform.Rotate (0,0,0);
            return;
        }
        transform.Rotate (0,0,30*Time.deltaTime);
    }

    void KillBoss()
    {
        bossDead = true;
        FindObjectOfType<AudioManager>().Play("hit");
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<MasterSpawner>().levelMax++;
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<MasterSpawner>().bossActive = false;
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
    
    void ShootRing()
    {
        for (var i = 0f; i < 360f; i += 10f)
        {
            var bullet = Instantiate(bulletPrefab, dropPoint.position, dropPoint.rotation * Quaternion.Euler(0,0,i));
            var rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
