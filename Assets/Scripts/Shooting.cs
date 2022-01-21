using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private bool shoot;

    public float shootTime;

    public float shootInterval = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;
        if(Input.GetButtonDown("Jump"))
        {
            shoot = true;
        }
        if(Input.GetButtonUp("Jump"))
        {
            shoot = false;
        }
        if (shoot && shootTime > shootInterval)
        {
            Shoot();
            shootTime = 0.0f;
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
}
