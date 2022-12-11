using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class UIManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TextMeshProUGUI txtTitle;
    [SerializeField]
    GameObject connectPanel;
    [SerializeField]
    GameObject lobbyPanel;
    [SerializeField]
    GameObject inRoomPanel;

    public void SetTitle(string _title)
    {
        txtTitle.text = _title;
    }
    public void ShowConnectPanel()
    {
        HideAllPanels();
        connectPanel.SetActive(true);
    }
    public void ShowLobbyPanel()
    {
        HideAllPanels();
        lobbyPanel.SetActive(true);
  
    }


    public void ShowInRoomPanel()
    {
        HideAllPanels();
        inRoomPanel.SetActive(true);
    }

    public void HideAllPanels() 
    {
        connectPanel.SetActive(false);
        lobbyPanel.SetActive(false);
        inRoomPanel.SetActive(false);
    }


    

 
}
