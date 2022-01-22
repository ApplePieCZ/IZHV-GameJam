// Script for sound implementation
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    
    [HideInInspector]
    public AudioSource source;


}