// Script for scrolling background
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 0.2f;
    
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
