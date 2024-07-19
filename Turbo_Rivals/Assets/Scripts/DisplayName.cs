using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public Text playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            playerNameText.text = playerName;
            UnityEngine.Debug.Log("Player name displayed: " + playerName);
        }
        else
        {
            playerNameText.text = "Player: Unknown";
            UnityEngine.Debug.LogWarning("No player name found in PlayerPrefs");
        }
    }
}
