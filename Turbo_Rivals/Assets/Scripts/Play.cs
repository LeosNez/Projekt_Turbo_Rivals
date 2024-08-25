using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject Canvas;

    public void Zacni()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
