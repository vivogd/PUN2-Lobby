using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using QFSW.QC;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject PlayerPrefab;

    [SerializeField]
    UIManager uiManager;

    [SerializeField]
    LobbyUI lobbyUI;
    private Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();

    #region Unity Methods

    void Start()
    {
        uiManager.ShowConnectPanel();
    }
    public void OnConnectPressed()
    {
        uiManager.HideAllPanels();
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true; // will sync scenes with master client
    }

    public void OnCreateRoomPressed()
    {
        CreateRandomRoom();

    }

   

    public void JoinRoom(string _roomName)
    {
        PhotonNetwork.JoinRoom(_roomName);
    }

    public void CreateRoom(string _roomName)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.CreateRoom(_roomName, roomOptions);
    }
    public void OnTryToJoinRoomPressed()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
       
    }

    private void CreateRandomRoom()
    {
        string roomName = "Room " + Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinLobby();
    }


    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            if (info.RemovedFromList)
            {
                cachedRoomList.Remove(info.Name);
            }
            else
            {
                cachedRoomList[info.Name] = info;
            }
        }
        lobbyUI.DisplayRoomList(cachedRoomList);
    }



    #endregion

    #region Photon Callbacks

    public override void OnConnected()
    {
        Debug.Log("Connected to internet");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName+" Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        cachedRoomList.Clear();
        Debug.Log("Disconnected");
    }

    public override void OnJoinedLobby()
    {
        cachedRoomList.Clear();
        uiManager.SetTitle(PhotonNetwork.NickName + " Joined Lobby");
        uiManager.ShowLobbyPanel();
    }
    public override void OnLeftLobby()
    {
        cachedRoomList.Clear();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // lets try to create a new room
        Debug.Log("Joind Room Failed");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("On Create Room");
    }


    public override void OnJoinedRoom()
    {
        uiManager.ShowInRoomPanel();
        uiManager.SetTitle(PhotonNetwork.NickName + " Joined Room: "+PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Joined room" + PhotonNetwork.CurrentRoom.Name);

         PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(Random.Range(-10f,10f),0,Random.Range(-10f,10f)), Quaternion.identity);
    }

 
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
         UpdateRoomList(roomList);
    }

    #endregion

    #region Command
    [Command]
    public void CountPlayers()
    {
        Debug.Log("Players Count " + PhotonNetwork.CountOfPlayers);
    }


    [Command]
    public void CountRooms()
    {
        Debug.Log("Room Count " + PhotonNetwork.CountOfRooms);
        Debug.Log("Room Players Count " + PhotonNetwork.CountOfPlayersInRooms);
        
    }



    #endregion
}
