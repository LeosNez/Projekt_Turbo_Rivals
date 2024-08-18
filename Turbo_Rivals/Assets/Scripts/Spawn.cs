using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject a;

    void Start()
    {
        Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
        Instantiate(a, randomSpawnPosition, Quaternion.identity);
    }
}
