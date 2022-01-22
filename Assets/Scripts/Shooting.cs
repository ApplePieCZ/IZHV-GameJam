using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform[] firePointField;

    public GameObject player;
    
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
        if (!shoot || shootTime <= shootInterval)
        { return; }
        
        
        switch (player.GetComponent<Player>().damage)
        {
            case 1:
                Shoot(firePointField[0]);
                break;
            case 2:
                Shoot(firePointField[1]);
                Shoot(firePointField[2]);
                break;
            case 3:
                Shoot(firePointField[0]);
                Shoot(firePointField[1]);
                Shoot(firePointField[2]);
                break;
            case 4:
                Shoot(firePointField[1]);
                Shoot(firePointField[2]);
                Shoot(firePointField[3]);
                Shoot(firePointField[4]);
                break;
            case 5:
                Shoot(firePointField[0]);
                Shoot(firePointField[1]);
                Shoot(firePointField[2]);
                Shoot(firePointField[3]);
                Shoot(firePointField[4]);
                break;
        }
        shootTime = 0.0f;
    }
    
    void Shoot(Transform firePoint)
    {
        FindObjectOfType<AudioManager>().Play("shot");
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
}
