using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;

    Vector2 _movement;

    public float health = 20f;

    public float damage = 1f;

    public bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (health <= 0.0f)
        {
            isDead = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        { return; }
        
        // Movement
        if (rb.position.x <= -8.25f && _movement.x == -1f)
        {
            _movement.x = 0;
        }

        if (rb.position.x >= 4.85f && _movement.x == 1f)
        {
            _movement.x = 0;
        }
        
        if (rb.position.y <= -4.75f && _movement.y == -1f)
        {
            _movement.y = 0;
        }

        if (rb.position.y >= 4.75f && _movement.y == 1f)
        {
            _movement.y = 0;
        }
        rb.MovePosition(rb.position + _movement * speed * Time.fixedDeltaTime);
    }

    private void KillPlayer()
    {
        
    }
}