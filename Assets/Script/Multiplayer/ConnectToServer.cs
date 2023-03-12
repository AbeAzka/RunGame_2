using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;


public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public Username username;
    private void Start()
    {
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

   
}
