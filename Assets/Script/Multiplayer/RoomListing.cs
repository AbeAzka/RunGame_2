using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private Text text;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }
}
