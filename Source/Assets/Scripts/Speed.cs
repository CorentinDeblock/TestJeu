using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public Transform player;
    public Text speedText;
    private float saveTime = 0;
    private float saveSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(saveTime + 0.1 <= Time.unscaledTime)
        {
            speedText.text = ((player.position.z - saveSpeed) * 10).ToString("0");
            saveTime = Time.unscaledTime;
            saveSpeed = player.position.z;
        }
    }
}

