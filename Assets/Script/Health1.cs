using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Health1 : MonoBehaviourPun
{
    public Image FillImage;

    [PunRPC]
    public void ReduceHealth(float amount)
    {
        ModifyHealth(amount);
    }

    private void ModifyHealth(float amount)
    {
        if (photonView.IsMine)
        {
            FillImage.fillAmount -= amount;
        }
        else
        {
            FillImage.fillAmount -= amount;
        }
    }
}
