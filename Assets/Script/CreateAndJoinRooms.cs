using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] public InputField createInput;
    [SerializeField] public InputField joinInput;
    [SerializeField] private GameObject UsernameMenu;

    [SerializeField] private GameObject ConnectPanel;
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject ListRoomMenu;

    private void Start()
    {
        ListRoomMenu.SetActive(false);
        UsernameMenu.SetActive(true);

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

    public void ShowListingRoom()
    {
        ListRoomMenu.SetActive(true);
    }

    public void HideListingMenu()
    {
        ListRoomMenu.SetActive(false);
    }
}
