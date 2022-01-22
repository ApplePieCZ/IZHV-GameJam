// Script for coin collision
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is "Despawner2" or "Player") Destroy(gameObject);
    }
}
