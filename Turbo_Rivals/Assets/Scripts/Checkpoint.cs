using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Vector3 lastCheckpointPosition;
    public Quaternion lastCheckpointRotation;

    public int counter = 0;
    public Text count;

    void Start()
    {
        lastCheckpointPosition = transform.position;
        lastCheckpointRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ReturnToLastCheckpoint();
        }

        count.text = counter.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpointPosition = new Vector3(other.transform.position.x, 2.867133f, other.transform.position.z);
            lastCheckpointRotation = other.transform.rotation;
        }

        if (other.CompareTag("Respawn"))
        {
            ReturnToLastCheckpoint();
        }

        if (other.CompareTag("Checkpoint1"))
        {
            if(counter == 0)
            {
                counter = 1;
            }
            else
            {
                ReturnToLastCheckpoint();
            }
        }

        if (other.CompareTag("Checkpoint2"))
        {
            counter = 2;
        }

        if (other.CompareTag("Checkpoint3"))
        {
            counter = 3;
        }

        if (other.CompareTag("Finish"))
        {
            if (counter != 3)
            {
                UnityEngine.Debug.Log("Neprojel jsi všechny checkpointy, budeš se muset vrátit :(");
            }
        }

        //if, který když hráè objede checkpoint tak ho to vrátí na poslední projetý checkpoint s tím, že neprojel checkpoint
    }

    private void ReturnToLastCheckpoint()
    {
        transform.position = lastCheckpointPosition;
        transform.rotation = lastCheckpointRotation;
    }
}