using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound a in sounds)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.loop = a.loop;
        }
    }

    void Start()
    {
        Play("Ambiance");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.clipName == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.clipName == name);
        s.source.Stop();
    }
}

//FindObjectOfType<AudioManager>().Play("Player");
