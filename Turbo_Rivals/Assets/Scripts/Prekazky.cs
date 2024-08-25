using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prekazky : MonoBehaviour
{
    private Rigidbody rb;
    public float ImpactForce = 10f; // Síla nárazu, kterou chceme aplikovat na překážku

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zabrana"))
        {
            // Získání vektoru rychlosti hráče
            Vector3 velocity = rb.velocity;

            // Získání normály povrchu při nárazu
            Vector3 normal = collision.contacts[0].normal;

            // Výpočet odraženého vektoru
            Vector3 reflectedVelocity = velocity - 2 * Vector3.Dot(velocity, normal) * normal;

            // Aplikace odraženého vektoru jako nové rychlosti hráče
            rb.velocity = reflectedVelocity;

            // Kontrola, zda má překážka Rigidbody (aby se mohla hýbat)
            Rigidbody obstacleRb = collision.collider.GetComponent<Rigidbody>();
            if (obstacleRb != null)
            {
                // Aplikace síly na překážku ve směru rychlosti hráče při nárazu
                obstacleRb.AddForce(velocity.normalized * ImpactForce, ForceMode.Impulse);
            }
        }
    }
}
