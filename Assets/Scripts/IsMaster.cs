using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class IsMaster : MonoBehaviourPunCallbacks
{

    GameObject masterMark;

    public override void OnJoinedRoom()
    {
        masterMark.SetActive(PhotonNetwork.IsMasterClient);
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {

        masterMark.SetActive(PhotonNetwork.IsMasterClient);
    }



}
