using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public Text Time_txt;

    void Start()
    {
        timeIsRunning = true;
    }

    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //pøevede èas z vteøin na minuty a zaokrouhlí smìrem dolù na celé minuty
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //vrátí zbytek a to jsou vteøiny
        Time_txt.text = string.Format("{0:00} : {1:00}", minutes, seconds); // slouží k formátování øetezce
    }
}