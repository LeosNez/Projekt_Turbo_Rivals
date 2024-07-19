using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmerSipky : MonoBehaviour
{
    public GameObject Sipka1;
    public GameObject Sipka2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sipka")
        {
            Sipka1.SetActive(false);
            Sipka2.SetActive(true);
        }
    }
}
