// Script for enemy shooting mechanism
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class EnemyShooting1 : MonoBehaviour
{
    public Transform[] firePointField;
    
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    
    public float shootTime;

    private float shootInterval = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;

        if (shootTime <= shootInterval) return;
        
        Shoot(firePointField[0]);
        Shoot(firePointField[1]);
        shootTime = 0.0f;
    }
    
    void Shoot(Transform firePoint)
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
}
