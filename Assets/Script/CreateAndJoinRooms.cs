using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] public InputField createInput;
    [SerializeField] public InputField joinInput;
    [SerializeField] private GameObject UsernameMenu;

    [SerializeField] private GameObject ConnectPanel;
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private GameObject StartButton;



    private void Start()
    {
        UsernameMenu.SetActive(true);
        PhotonNetwork.SendRate = 20;
        PhotonNetwork.SerializationRate = 5;
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }

    public void ChangeUsernameInput()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.NickName = UsernameInput.text;
    }

    public void connectBtn()
    {
        SceneManager.LoadScene("Loading");
    }

    
}
