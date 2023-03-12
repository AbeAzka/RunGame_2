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
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);

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
        if (result.Data != null && result.Data.ContainsKey("Username"))
        {
        }
        else
        {
            Debug.Log("Player data not complete!");
        }
    }
    public void SaveUsername()
    {
        PhotonNetwork.NickName = inputField.text;

        PlayerPrefs.SetString("Username", inputField.text);

        MyUsername.text = inputField.text;

        UsernamePage.SetActive(false);

        Save();
    }

    void Save()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>()
            {
                {"Name", PlayerPrefs.GetString("Username", inputField.text)},
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
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
