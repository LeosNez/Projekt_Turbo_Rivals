using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public InputField inputField;

    public void SavePlayerName()
    {
        string playerName = inputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        UnityEngine.Debug.Log("Player name saved: " + playerName);
    }
}
