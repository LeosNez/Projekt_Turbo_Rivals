using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource audioSource;  // AudioSource komponenta

    void Update()
    {
        // Kontrolujeme, jestli byla stisknuta klávesa (napø. klávesa "space")
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            audioSource.gameObject.SetActive(false);
        }
    }
}
