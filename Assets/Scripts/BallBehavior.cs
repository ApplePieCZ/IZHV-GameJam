using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is "EnemyBullet(Clone)" or "Coin(Clone)" or "Bullet(Clone)" or "Ball(Clone)") return;
        Destroy(gameObject);
    }
}
