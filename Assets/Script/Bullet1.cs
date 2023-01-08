using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Bullet1 : MonoBehaviour
{
    public bool MoveDir = false;

    public float MoveSpeed;

    public float DestroyTime;
    PhotonView view;

    private void Awake()
    {
        StartCoroutine("DestroyByTime");
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
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }

        
    }

    
}
