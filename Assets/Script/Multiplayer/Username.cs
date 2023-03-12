using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Username : MonoBehaviour
{
    public InputField inputField;
    public GameObject UsernamePage;
    public Text MyUsername;

    void Start()
    {
        if (PlayerPrefs.GetString("Username") == "" || PlayerPrefs.GetString("Username") == null)
        {
            UsernamePage.SetActive(true);
        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("Username");

            MyUsername.text = PlayerPrefs.GetString("Username");

            UsernamePage.SetActive(false);
        }
    }

    public void OpenUsernamePage()
    {
        UsernamePage.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CancelUsernamePage()
    {
        UsernamePage.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SaveUsername()
    {
        PhotonNetwork.NickName = inputField.text;

        PlayerPrefs.GetString("Username", inputField.text);

        MyUsername.text = inputField.text;

        UsernamePage.SetActive(false);
    }
}
