using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    public static SpawnPlayer Instance;
    public GameObject playerPrefab;
    public GameObject SceneCamera;
    public Text PingText;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [HideInInspector] public GameObject LocalPlayer;
    public Text RespawnTimerText;
    public GameObject RespawnMenu;
    private float TimerAmount = 5f;
    private bool RunSpawnTimer = false;

    private void Awake()
    {
        Instance = this;
    }
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

        if (RunSpawnTimer)
        {
            StartRespawn();
        }
    }

    public void EnableRespawn()
    {
        TimerAmount = 5f;
        RunSpawnTimer = true;
        RespawnMenu.SetActive(true);
    }
    

    private void StartRespawn()
    {
        TimerAmount -= Time.deltaTime;
        RespawnTimerText.text = "RESPAWNING IN " + TimerAmount.ToString("F0");

        if (TimerAmount <= 0)
        {
            LocalPlayer.GetComponent<PhotonView>().RPC("Respawn", RpcTarget.AllBuffered);
            LocalPlayer.GetComponent<Health1>().EnableInput();
            RespawnLocation();
            RespawnMenu.SetActive(false);
            RunSpawnTimer = false;
        }
    }

    public void RespawnLocation()
    {
        float randomValue = Random.Range(-3, 5f);
        LocalPlayer.transform.localPosition = new Vector2(randomValue, 3f);
    }
}
