using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skokanek : MonoBehaviour
{
    public float jumpForce = 10f; // Síla skoku
    public float jumpDistance = 5f; // Vzdálenost, kterou auto uletí po skoku

    private bool isOnSlope = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slope")) // Pokud narazí na naklonìnou plochu
        {
            isOnSlope = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slope")) // Pokud opustí naklonìnou plochu
        {
            isOnSlope = false;
            Jump(); // Provádí skok, protože auto opustilo rampu
        }
    }

    void Jump()
    {
        if (isOnSlope) return; // Pokud je ještì auto na rampì, neproveïte skok
        Rigidbody rb = GetComponent<Rigidbody>(); // Pøístup k Rigidbody vozidla
        rb.AddForce(transform.forward * jumpDistance, ForceMode.Impulse); // Aplikace síly smìrem vpøed pro let po skoku. ForceMode.Impulse zajistí, že se ptovede hned
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplikace síly smìrem nahoru pro skok
    }
}
