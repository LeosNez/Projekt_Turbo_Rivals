using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prekazky : MonoBehaviour
{
    // Reference to the Rigidbody component of the obstacle
    private Rigidbody rb;

    // Variable to specify how strong the force should be to knock down the obstacle
    public float knockdownForce = 50f;

    // Check if the obstacle has already been knocked down
    private bool isKnockedDown = false;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player and if the obstacle hasn't been knocked down yet
        if (collision.gameObject.CompareTag("Player") && !isKnockedDown)
        {
            // Calculate the force direction
            Vector3 forceDirection = transform.position - collision.contacts[0].point;

            // Apply force to the obstacle in the calculated direction
            rb.AddForce(forceDirection.normalized * knockdownForce, ForceMode.Impulse);

            // Set the obstacle as knocked down
            isKnockedDown = true;

            // Optionally, you can add other effects like playing a sound or particle effects here
        }
    }
}
