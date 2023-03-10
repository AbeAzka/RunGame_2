using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Home : MonoBehaviourPunCallbacks
{
    public void Back(int sceneID)
    {
        PhotonNetwork.Disconnect();
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

 
}
