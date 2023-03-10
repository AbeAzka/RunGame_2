using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUnlock1 : MonoBehaviour
{

    int levelUnlocked;

    public Button[] levelButtons;

    void Start()
    {
        levelUnlocked = PlayerPrefs.GetInt("ReachedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < levelUnlocked; i++)
        {
            levelButtons[i].interactable = true;
        }

    }

    public void LoadLevel(int levelindex)
    {
        SceneManager.LoadScene(levelindex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Start");
    }

}
