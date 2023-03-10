using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Sel_Level");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting From RunGame 2");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Loading");
        Debug.Log("Scene Loaded...");
    }
}