// Script for bullet collision
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is ("Despawner2" or "Player" or "Despawner1" or "Despawner3" or "Despawner4")) Destroy(gameObject);
    }
}
