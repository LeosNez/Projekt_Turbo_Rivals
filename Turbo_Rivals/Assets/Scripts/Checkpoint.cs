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
            lastCheckpointPosition = new Vector3(other.transform.position.x, 4.091284f, other.transform.position.z);
            lastCheckpointRotation = other.transform.rotation;
        }

        if (other.CompareTag("Respawn"))
        {
            ReturnToLastCheckpoint();
        }

        if (other.CompareTag("Checkpoint1"))
        {
            counter = 1;
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

        if (other.CompareTag("Checkpoint_exit"))
        {
            ReturnToLastCheckpoint();
            UnityEngine.Debug.Log("Neprojel jsi checkpoint");
        }
    }

    private void ReturnToLastCheckpoint()
    {
        transform.position = lastCheckpointPosition;
        transform.rotation = lastCheckpointRotation;
    }
}