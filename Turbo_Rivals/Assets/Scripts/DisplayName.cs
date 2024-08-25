using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayName : MonoBehaviour
{
    public Text PlayerNameText; 

    void Start()
    {
        if (!string.IsNullOrEmpty(PlayerName.PlyrName))
        {
            PlayerNameText.text = PlayerName.PlyrName;
        }
        else
        {
            //SceneManager.LoadScene(6);
            UnityEngine.Debug.Log("Zadej své uživatelské jméno");
        }
    }
}
