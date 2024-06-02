using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            musicSource.Play();
        }
    }
}
