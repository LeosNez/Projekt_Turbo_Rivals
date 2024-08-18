using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource Jede;
    public AudioSource Stoji;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jede.gameObject.SetActive(true);
            Stoji.gameObject.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Jede.gameObject.SetActive(false);
            Stoji.gameObject.SetActive(true);
        }
    }
}
