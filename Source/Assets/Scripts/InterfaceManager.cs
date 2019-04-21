using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public List<ContentSwitch> button;
    public string relativePath = "Scenes/";
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void switchUI(string name)
    {
        foreach(ContentSwitch content in button)
        {
            if(content.name == name)
            {
                content.hide.SetActive(false);
                content.show.SetActive(true);
            }
        }
    }
    public void transitionLevel(string level,string song)
    {
        SceneManager.LoadScene(relativePath + level);
        SoundManager.SoundLibrary().stop();
        SoundManager.SoundLibrary().play(song);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void transitionToLevel(string level)
    {
        transitionLevel(level, "Level");
    }
    public void playEffect(string effect)
    {
        SoundManager.SoundLibrary().play(effect);
    }
    public void resumeClick()
    {
        GameManager.getGameManager().pause();
    }
    public void saveSetting(string filename)
    {
        Equalizer eq = FindObjectOfType<Equalizer>();
        if (eq)
        {
            eq.save(filename);
        }
        else
        {
            print("Not save");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
