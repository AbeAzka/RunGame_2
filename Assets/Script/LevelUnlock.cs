using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    public Button[] levelButtons;

    public void Start()
    {
        foreach (Button b in levelButtons)
            b.interactable = false;

        int reachedLevel = PlayerPrefs.GetInt("ReachingLevel", 1);

        for (int i = 0; i < reachedLevel; i++)
            levelButtons[i].interactable = true;
    }
}
