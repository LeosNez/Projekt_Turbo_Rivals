using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject camNormal;
    public GameObject camZoom;
    public GameObject camPlayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camNormal.SetActive(true);
            camZoom.SetActive(false);
            camPlayer.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camNormal.SetActive(false);
            camZoom.SetActive(true);
            camPlayer.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camNormal.SetActive(false);
            camZoom.SetActive(false);
            camPlayer.SetActive(true);
        }
    }
}
