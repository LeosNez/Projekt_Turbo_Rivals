using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject CaraV1;
    public GameObject CaraV2;

    public GameObject CaraO1;
    public GameObject CaraO2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kaluz"))
        {
            CaraV1.SetActive(true);
            CaraV2.SetActive(true);
        }

        if (other.CompareTag("Olejik"))
        {
            CaraO1.SetActive(true);
            CaraO2.SetActive(true);
        }

        if (other.CompareTag("Respawn"))
        {
            CaraV1.SetActive(false);
            CaraV2.SetActive(false);
            CaraO1.SetActive(false);
            CaraO2.SetActive(false);
        }
    }
}