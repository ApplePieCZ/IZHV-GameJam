// Script for audio management
// Author: Lukas Marek
// Date: 22.01.2022
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    [SerializeField] Slider volumeSlider;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
            PlayerPrefs.SetFloat("masterVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        Play("theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("masterVolume", volumeSlider.value);
    }


}