using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public static string playerName;
    public InputField inputField;

    public void SavePlayerName()
    {
        playerName = inputField.text;
    }
}