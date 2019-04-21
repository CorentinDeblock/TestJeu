using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;
    public GameObject pauseUI;
    public Transform spawn;

    private bool paused = false;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void win()
    {
        winUI.SetActive(true);
       
    }
    public void restart(Player play)
    {
        play.transform.position = spawn.position;
    }
    public void pause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
            paused = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public static GameManager getGameManager()
    {
        return FindObjectOfType<GameManager>();
    }
}