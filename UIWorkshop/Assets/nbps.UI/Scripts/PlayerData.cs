using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public TMP_Text playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        string playerName = PlayerPrefs.GetString("username");
        playerNameText.text = "Welcome " + playerName;
    }
}
