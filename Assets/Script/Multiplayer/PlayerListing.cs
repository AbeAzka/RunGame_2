using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text text;

    private Player player;
    public void SetPlayerInfo(Player player)
    {
        player = player;
        text.text = PhotonNetwork.NickName;
    }
}
