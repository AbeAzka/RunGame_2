using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject SceneCamera;
    public Text PingText;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        SceneCamera.SetActive(false);
    }

    

    private void Update()
    {
        PingText.text = "Ping: " + PhotonNetwork.GetPing();
        if (PingText.text.Length >= 9)
        {
            PingText.color = Color.red;
        }
        if (PingText.text.Length == 8)
        {
            PingText.color = Color.yellow;
        }
        if (PingText.text.Length == 7)
        {
            PingText.color = Color.green;
        }
    }
}
