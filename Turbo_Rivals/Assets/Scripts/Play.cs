using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject canvas;

    public void Zacni()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
