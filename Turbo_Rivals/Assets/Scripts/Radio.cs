using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public AudioSource RadioSource;
    public AudioClip[] ListSongu;

    public Toggle myToggle;

    void Start()
    {
        // Naètení stavu Toggle pøi startu hry
        if (PlayerPrefs.HasKey("ToggleState"))
        {
            myToggle.isOn = PlayerPrefs.GetInt("ToggleState") == 1;
        }
        else
        {
            myToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!RadioSource.isPlaying)
        {
            AudioClip randomClip = ListSongu[UnityEngine.Random.Range(0, ListSongu.Length)];

            RadioSource.PlayOneShot(randomClip);
        }
    }

    void OnDisable()
    {
        // Uložení stavu Toggle pøi deaktivaci objektu (napø. pøi zmìnì scény)
        SaveToggleState();
    }

    void SaveToggleState()
    {
        // Uložení stavu Toggle (1 pokud je zapnutý, 0 pokud je vypnutý)
        PlayerPrefs.SetInt("ToggleState", myToggle.isOn ? 1 : 0);
        PlayerPrefs.Save(); // Volitelnì mùžete zavolat Save() pro zajištìní okamžitého uložení
    }
}
