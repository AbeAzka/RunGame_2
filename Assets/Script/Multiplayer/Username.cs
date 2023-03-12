using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;

public class Username : MonoBehaviour
{
    public InputField inputField;
    public GameObject UsernamePage;
    public Text MyUsername;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "FE39E";
        }

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

    void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received user data!");
        if (result.Data != null && result.Data.ContainsKey("Username") && result.Data.ContainsKey("UserInfo") && result.Data.ContainsKey("MyUsername"))
        {
            PhotonNetwork.NickName = inputField.text;
            PlayerPrefs.GetString("Username", inputField.text);
            MyUsername.text = inputField.text;
        }
    }
    public void SaveUsername()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>()
            {
                {"Username", PhotonNetwork.NickName = inputField.text},
                {"UserInfo", PlayerPrefs.GetString("Username", inputField.text) },
                {"MyUsername",  MyUsername.text = inputField.text }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

        PhotonNetwork.NickName = inputField.text;

        PlayerPrefs.GetString("Username", inputField.text);

        MyUsername.text = inputField.text;

        UsernamePage.SetActive(false);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successful user data send!");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error with PlayFab");
        Debug.Log(error.GenerateErrorReport());
    }







}
