using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeRemaining = 0;
    public bool TimeIsRunning = true;
    public Text Time_txt;

    void Start()
    {
        TimeIsRunning = true;
    }

    void Update()
    {
        if (TimeIsRunning)
        {
            TimeRemaining += Time.deltaTime;
            DisplayTime(TimeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //pøevede èas z vteøin na minuty a zaokrouhlí smìrem dolù na celé minuty
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //vrátí zbytek a to jsou vteøiny
        float milliseconds = Mathf.FloorToInt((timeToDisplay * 100) % 100); // Získání setin sekundy
        Time_txt.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds); // slouží k formátování stringu
    }
}