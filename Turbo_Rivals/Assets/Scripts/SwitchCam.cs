using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject CamNormal;
    public GameObject CamZoom;
    public GameObject CamPlayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CamNormal.SetActive(true);
            CamZoom.SetActive(false);
            CamPlayer.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CamNormal.SetActive(false);
            CamZoom.SetActive(true);
            CamPlayer.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CamNormal.SetActive(false);
            CamZoom.SetActive(false);
            CamPlayer.SetActive(true);
        }
    }
}
