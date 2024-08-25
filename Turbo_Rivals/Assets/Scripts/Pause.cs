using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ZastavHru();
        }
    }
    void ZastavHru()
    {
        Time.timeScale = 0f;

        if (Canvas != null)
        {
            Canvas.gameObject.SetActive(true);
        }
    }
}