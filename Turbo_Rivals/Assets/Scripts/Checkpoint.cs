using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 lastCheckpointPosition;
    public Quaternion lastCheckpointRotation;

    void Start()
    {
        lastCheckpointPosition = transform.position;
        lastCheckpointRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ReturnToLastCheckpoint();
        }
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
    }

    private void ReturnToLastCheckpoint()
    {
        transform.position = lastCheckpointPosition;
        transform.rotation = lastCheckpointRotation;
    }
}