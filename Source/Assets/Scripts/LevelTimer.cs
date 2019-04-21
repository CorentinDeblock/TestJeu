using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private Timer timer = new Timer();
    public Text timeFont;
    // Start is called before the first frame update
    void Start()
    {
        timer.startChrono();
    }
    public void resetChrono()
    {
        timer.stopChrono();
    }
    // Update is called once per frame
    void Update()
    {
        if (timeFont)
        {
            timeFont.text = timer.getTime().ToString("0.000");
        }
    }
}
