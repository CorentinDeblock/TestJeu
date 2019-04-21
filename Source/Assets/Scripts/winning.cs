using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winning : MonoBehaviour
{
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.getGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        manager.win();
    }
}
