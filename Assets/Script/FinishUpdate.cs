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
            int CompleteLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (CompleteLevel == 7)
                SceneManager.LoadScene(9);
            if (PlayerPrefs.GetInt("ReachedLevel", 1) < CompleteLevel)
                PlayerPrefs.SetInt("ReachedLevel", CompleteLevel);
            SceneManager.LoadScene(CompleteLevel);
        }
    }

  
}