// Script for bullet collision
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is "EnemyBullet(Clone)" or "Coin(Clone)" or "Bullet(Clone)") return;

        Destroy(gameObject);
    }
}
