using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class ConnectUI : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;
    string defaultName;
    void Start()
    {
        if (inputField != null)
        {

            if (PlayerPrefs.HasKey("PlayerName"))
            {
                defaultName = PlayerPrefs.GetString("PlayerName");
                inputField.text = defaultName;
            }
        }
    }

    public void SetPlayerName(string value)
    {
        // #Important
        if (string.IsNullOrEmpty(value))
        {
            value = "Player" + Random.Range(0, 100);
            return;
        }
        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString("PlayerName", value);
    }


}
