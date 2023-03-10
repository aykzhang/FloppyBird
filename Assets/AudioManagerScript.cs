using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name){
        //find sound in sounds array where sound.name == name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        //Only play if not muted by settings
        if((PlayerPrefs.GetInt("Music") == 0 && s.type == 0) || (PlayerPrefs.GetInt("Sound") == 0 && s.type == 1))
            s.source.Play();
    }

    public void Stop(string name){
        //find sound in sounds array where sound.name == name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }
}
