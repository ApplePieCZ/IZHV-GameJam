using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LaserBomb : MonoBehaviour
{
    private float elapsedTime;
    
    public GameObject bulletPrefab;
    
    private float bulletForce = 5f;
    
    public Transform firePoint;
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 0.5f)
        {
            Shoot();
            Destroy(gameObject);
        }
    }
    
    void Shoot()
    {
        for (var i = 0f; i < 360f; i += 45f)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0,0,i));
            var rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is "Despawner2" or "Player") Destroy(gameObject);
    }
}
