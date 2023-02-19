using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Home : MonoBehaviour
{
    public void Back(int sceneID)
    {
        PhotonNetwork.LeaveLobby();
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
