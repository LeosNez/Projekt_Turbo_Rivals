using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Vector3 LastCheckpointPosition;
    public Quaternion LastCheckpointRotation;

    public int Counter = 0;
    public Text Count_txt;

    void Start()
    {
        LastCheckpointPosition = transform.position;
        LastCheckpointRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ReturnToLastCheckpoint();
        }

        Count_txt.text = Counter.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            LastCheckpointPosition = new Vector3(other.transform.position.x, 4.091284f, other.transform.position.z);
            LastCheckpointRotation = other.transform.rotation;
        }

        if (other.CompareTag("Respawn"))
        {
            ReturnToLastCheckpoint();
        }

        if (other.CompareTag("Checkpoint1"))
        {
            Counter = 1;
        }

        if (other.CompareTag("Checkpoint2"))
        {
            Counter = 2;
        }

        if (other.CompareTag("Checkpoint3"))
        {
            Counter = 3;
        }

        if (other.CompareTag("Finish"))
        {
            if (Counter != 3)
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
        transform.position = LastCheckpointPosition;
        transform.rotation = LastCheckpointRotation;
    }
}