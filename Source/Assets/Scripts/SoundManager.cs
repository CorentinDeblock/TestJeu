using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{
    public AudioStruct[] sounds;

    private AudioSource getSource(string name)
    {
        AudioStruct s = Array.Find(sounds, sound => sound.title == name);
        return s.source;
    }
    public AudioStruct[] getSourceByCategories(string category)
    {
        List<AudioStruct> structs = new List<AudioStruct>();
        foreach (AudioStruct a in sounds)
        {
            if(category == a.category)
            {
                structs.Add(a);
            }
        }
        return structs.ToArray();
    }
    private void loopLibrarySource(string name,Action<AudioSource> callback)
    {
        callback(getSource(name));
    }
    private void loopLibrarySource(Action<AudioSource> callback)
    {
        foreach (AudioStruct a in sounds)
        {
            callback(a.source);
        }
    }
    private void loopLibrarySource(string[] name, Action<AudioSource> callback)
    {
        foreach (AudioStruct a in sounds)
        {
            foreach(string title in name)
            {
                if(a.title == title)
                {
                    callback(a.source);
                }
            }
        }
    }
    private void Awake()
    {
        GameObject same = GameObject.Find(gameObject.name);
        if (same && same != this.gameObject)
        {
            Destroy(same);
        }
        foreach (AudioStruct sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void pause(string[] name)
    {
        loopLibrarySource(name, source => source.Pause());
    }
    public void pause(string name)
    {
        loopLibrarySource(name, source => source.Pause());
    }
    public void pause()
    {
        loopLibrarySource(source => source.Pause());
    }

    public void stop(string[] name)
    {
        loopLibrarySource(name, source => source.Stop());
    }
    public void stop(string name)
    {
        loopLibrarySource(name, source => source.Stop());
    }
    public void stop()
    {
        loopLibrarySource(source => source.Stop());
    }
    public static SoundManager SoundLibrary()
    {
        return FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play(string name)
    {
        loopLibrarySource(name, source => source.Play());
    }

    public void play(string[] name)
    {
        loopLibrarySource(name, source => source.Play());
    }
}
