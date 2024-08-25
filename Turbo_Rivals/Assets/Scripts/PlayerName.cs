using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public static string PlyrName;
    public InputField InputField;

    public void SavePlayerName()
    {
        PlyrName = InputField.text;
    }
}