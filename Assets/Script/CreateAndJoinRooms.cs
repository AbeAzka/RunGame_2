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

    private void Warning()
    {
        
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
