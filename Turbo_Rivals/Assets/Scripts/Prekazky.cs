using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prekazky : MonoBehaviour
{
    private Rigidbody rb;

    public float knockdownForce = 50f;

    private bool isKnockedDown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player and if the obstacle hasn't been knocked down yet
        if (collision.gameObject.CompareTag("Player") && !isKnockedDown)
        {
            // Calculate the force direction
            // collision.contacts[0].point je místo prvního kontaktu pøi kolizi
            Vector3 forceDirection = transform.position - collision.contacts[0].point;

            // Apply force to the obstacle in the calculated direction
            // forceDirection.normalized zajistí, že síla bude aplikována ve správném smìru s jednotkovou délkou
            rb.AddForce(forceDirection.normalized * knockdownForce, ForceMode.Impulse);

            // Set the obstacle as knocked down
            isKnockedDown = true;
        }
    }
}
