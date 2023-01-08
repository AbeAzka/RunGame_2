using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class Health1 : MonoBehaviourPun
{
    public Image FillImage;

    public float HealthAmount;

    public Player plMove;
    public Rigidbody2D rb;
    
    public BoxCollider2D bc;
    public SpriteRenderer sr;
    public GameObject PlayerCanvas;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            SpawnPlayer.Instance.LocalPlayer = this.gameObject;
        }
    }
    [PunRPC]
    public void ReduceHealth(float amount)
    {
        ModifyHealth(amount);
    }

    private void CheckHealth()
    {
        FillImage.fillAmount = HealthAmount / 100f;
        if (photonView.IsMine && HealthAmount <= 0)
        {
            SpawnPlayer.Instance.EnableRespawn();
            plMove.DisableInput = true;
            this.GetComponent<PhotonView>().RPC("Dead", RpcTarget.AllBuffered);
        }
    }

    public void EnableInput()
    {
        plMove.DisableInput = false;
    }

    [PunRPC]
    private void Dead()
    {
        rb.gravityScale = 0;
        bc.enabled = false;
        sr.enabled = false;
        PlayerCanvas.SetActive(false);
    }

    [PunRPC]
    private void Respawn()
    {
        rb.gravityScale = 1;
        bc.enabled = true;
        sr.enabled = true;
        PlayerCanvas.SetActive(true);
        FillImage.fillAmount = 1f;
        HealthAmount = 100f;
    }

    private void ModifyHealth(float amount)
    {
        if (photonView.IsMine)
        {
            HealthAmount -= amount;
            FillImage.fillAmount -= amount;
        }
        else
        {
            HealthAmount -= amount;
            FillImage.fillAmount -= amount;
        }
        CheckHealth();
    }
}
