using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayName : MonoBehaviour
{
    public Text playerNameText; 

    void Start()
    {
        if (!string.IsNullOrEmpty(PlayerName.playerName))
        {
            playerNameText.text = PlayerName.playerName;
        }
        else
        {
            //SceneManager.LoadScene(6);
            UnityEngine.Debug.Log("Zadej své uživatelské jméno");
        }
    }
}
