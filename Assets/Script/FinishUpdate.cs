using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishUpdate : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

            if (currentLevel == 11)
            {
                SceneManager.LoadScene("End_Screen");
            }

            if (currentLevel > PlayerPrefs.GetInt("ReachedLevel"))
            {
                PlayerPrefs.SetInt("ReachedLevel", currentLevel + 0);
            }

            Debug.Log("LEVEL" + PlayerPrefs.GetInt("ReachedLevel") + " UNLOCKED");
            SceneManager.LoadScene(nextLevel);
        }
    }

  
}