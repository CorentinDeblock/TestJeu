using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private bool started = false;
    private float elapsed = 0;
    // Update is called once per frame
    public void startChrono()
    {
        elapsed = Time.realtimeSinceStartup;
        started = true;
    }

    public void stopChrono()
    {
        elapsed = Time.realtimeSinceStartup;
        started = false;
    }
    public bool isStarted()
    {
        return started;
    }
    public float getTime()
    {
        return Time.realtimeSinceStartup - elapsed;
    }
}
