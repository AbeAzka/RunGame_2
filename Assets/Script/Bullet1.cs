using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet1 : MonoBehaviourPun, IPunObservable
{
    public bool MoveDir = false;

    public float MoveSpeed;

    public float DestroyTime;

    public float BulletDamage;

    
    private void Awake()
    {
        StartCoroutine("DestroyByTime");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            transform.position = (Vector2)stream.ReceiveNext();
        }
    }

    IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(DestroyTime);
        this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void ChangeDir_left()
    {
        MoveDir = true;
    }

    [PunRPC]
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (!MoveDir)
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!photonView.IsMine)
            return;

        PhotonView target = collision.gameObject.GetComponent<PhotonView>();

        if (target != null && (!target.IsMine || target.IsRoomView))
        {
            if (target.tag == "Player")
            {
                target.RPC("ReduceHealth", RpcTarget.AllBuffered, BulletDamage);
            }
            this.GetComponent<PhotonView>().RPC("DestroyObject", RpcTarget.AllBuffered);
        }
    }
}