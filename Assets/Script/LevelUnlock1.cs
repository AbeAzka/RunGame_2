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

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
