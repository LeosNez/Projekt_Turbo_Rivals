using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cil : MonoBehaviour
{
    public GameObject Finish;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Finish.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}