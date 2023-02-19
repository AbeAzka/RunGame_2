using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUnlock1 : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        foreach (Button b in levelButtons)
            b.interactable = false;

        int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);

        for (int i = 0; i < reachedLevel; i++)
            levelButtons[i].interactable = true;

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadGame_1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadGame_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void LoadGame_3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void LoadGame_4()
    {
        SceneManager.LoadScene("Level_4");
    }

    public void LoadGame_5()
    {
        SceneManager.LoadScene("Level_5");
    }

    public void LoadGame_6()
    {
        SceneManager.LoadScene("Level_6");
    }

    public void LoadGame_7()
    {
        SceneManager.LoadScene("Level_7");
    }

    public void LoadGame_8()
    {
        SceneManager.LoadScene("Level_8");
    }
}
