using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject caraV1;
    public GameObject caraV2;

    public GameObject caraO1;
    public GameObject caraO2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kaluz"))
        {
            caraV1.SetActive(true);
            caraV2.SetActive(true);
        }

        if (other.CompareTag("Olejik"))
        {
            caraO1.SetActive(true);
            caraO2.SetActive(true);
        }
    }
}