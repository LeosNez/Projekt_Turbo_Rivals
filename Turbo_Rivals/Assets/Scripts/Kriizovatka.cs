using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kriizovatka : MonoBehaviour
{
    public GameObject Zabrana1;
    public GameObject Zabrana2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DobrySmer"))
        {
            Zabrana1.SetActive(false);
            Zabrana2.SetActive(false);
        }
    }
}
