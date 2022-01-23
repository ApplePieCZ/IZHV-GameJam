using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosSpawner : MonoBehaviour
{
    public bool spawn;

    public Transform _transform;
    public GameObject ballPrefab;
    private const float left = -8.8f;
    private const float right = 4.8f;
    private const float top = 5f;
    private const float bottom = -5f;
    private const float shift = 0.5f;
    private float spawnTime = 0.13f;
    private float elapsedTime = 0.0f;
    void FixedUpdate()
    {
        if (!spawn) return;
        elapsedTime += Time.deltaTime;
        if (!(elapsedTime >= spawnTime)) return;
        elapsedTime = 0f;
        Vector3 direction = new Vector3();
        int side = Random.Range(0, 4);
        float x = Random.value, y = Random.value;
        switch (side)
        {
            case 0: //top
                x = x*(right - left) + left;
                y = top + shift;
                direction = _transform.up * -1;
                break;
            case 1: //right
                x = right + shift;
                y = y*(top - bottom) + bottom;
                direction = _transform.right * -1;
                break;
            case 2: //bottom
                x = x*(right - left) + left;
                y = bottom - shift;
                direction = _transform.up;
                break;
            case 3: //left
                x = left - shift;
                y = y*(top - bottom) + bottom;
                direction = _transform.right;
                break;
        }
        var ball = Instantiate(ballPrefab, new Vector3(x,y,0), _transform.rotation);
        var rigidBody = ball.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(direction * 5f, ForceMode2D.Impulse);
    }
}