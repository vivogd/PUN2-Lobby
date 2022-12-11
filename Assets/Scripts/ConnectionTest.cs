using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionTest : MonoBehaviourPunCallbacks
{
    RoomOptions roomOptions;
    string roomName;
    private void Start()
    {
        PhotonNetwork.CreateRoom(roomName, roomOptions);
        
        PhotonNetwork.JoinRoom(roomName);
        
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        
        PhotonNetwork.JoinRandomOrCreateRoom();
    }  


    private void ShowScore()
    {

        //Saving
        PlayerPrefs.SetString("PlayerName", "Aviv");
        PlayerPrefs.SetInt("Score", 40);
        
         
        //Retieving 
        PlayerPrefs.GetString("PlayerName"); // Aviv
        PlayerPrefs.GetInt("Score");         //  40

    }

    #region Public Methods
    private void OnEnable()
    {

    }
    private void Update()
    {

    }
    #endregion

    #region Photon Callbacls

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }
    #endregion

}
