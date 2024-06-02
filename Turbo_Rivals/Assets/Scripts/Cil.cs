using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cil : MonoBehaviour
{
    public GameObject Finish;
    public GameObject Tachomer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Finish.SetActive(true);
            Tachomer.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}