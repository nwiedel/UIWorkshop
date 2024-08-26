using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace nbps.UI.Scripts._backup
{
    public class PlayerData : MonoBehaviour
    {
        public TMP_Text playerNameText;

        // Start is called before the first frame update
        void Start()
        {
            string _playerName = PlayerPrefs.GetString("username");
            playerNameText.text = $"Welcome {_playerName}";
        }
    }
}
