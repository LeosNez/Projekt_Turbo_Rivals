using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject canvas;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f;
            canvas.gameObject.SetActive(true);
        }
    }
}
