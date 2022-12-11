using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class LobbyUI : MonoBehaviour

{
    [SerializeField]    TextMeshProUGUI roomName;

    [SerializeField]    RoomItemUI roomItemPrefab;

    [SerializeField]    Transform roomsParent;

 
    public void DisplayRoomList(Dictionary<string, RoomInfo> roomList)
    {

        Debug.Log("DisplayRoomList" + roomList.Count);
        
        foreach (Transform child in roomsParent)
        {
            RoomItemUI.Destroy(child.gameObject);
        }

        //Display List
        foreach (KeyValuePair<string, RoomInfo> rooInfo in roomList)
        {
            var item = Instantiate(roomItemPrefab.gameObject, roomsParent);
            item.GetComponent<RoomItemUI>().SetName(rooInfo.Value.Name);
  
        }
    }


    public void CreateARoom()
    {
        if (!string.IsNullOrEmpty(roomName.text))
        {
            FindObjectOfType<NetworkManager>().CreateRoom(roomName.text);
        }
    }




}
