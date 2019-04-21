using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private bool playing = false;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            Equalizer eq = FindObjectOfType<Equalizer>();
            if (eq)
            {
                eq.load("Equalizer");
                print("Loaded");
            }
            SoundManager.SoundLibrary().play("Menu theme");   
            playing = true;
        }
    }
}
