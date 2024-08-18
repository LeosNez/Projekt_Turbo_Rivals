using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource radioSource;

    public AudioClip[] listSongu;

    // Start is called before the first frame update
    void Start()
    {
        //AudioClip randomClip = listSongu[UnityEngine.Random.Range(0, listSongu.Length)];

        //radioSource.PlayOneShot(randomClip);
    }

    // Update is called once per frame
    void Update()
    {
        if (!radioSource.isPlaying)
        {
            AudioClip randomClip = listSongu[UnityEngine.Random.Range(0, listSongu.Length)];

            radioSource.PlayOneShot(randomClip);
        }
    }
}
