using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoomItemUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI roomName;
    [SerializeField] TextMeshProUGUI MaxPlayers;
 

    public void SetName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void OnJoinedPressed()
    {
        FindObjectOfType<NetworkManager>().JoinRoom(roomName.text);
    }
}
