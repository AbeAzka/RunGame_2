using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text text;

    public RoomInfo RoomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = roomInfo.Name + ", " + roomInfo.MaxPlayers;
    }

    public void OnClick_Btn()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
