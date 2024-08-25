using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Louze : MonoBehaviour
{
    public GameObject Cak;

    private void OnTriggerEnter(Collider other)
    {
        //Když vjede hhráè do louže, tak se tam spawnou kulièky (kapky vody)
        if (other.CompareTag("Kaluz"))
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Instantiate(Cak, new Vector3(transform.position.x + i, 0.5f, transform.position.z + j), Quaternion.identity);
                }
            }
        }
    }
}
