using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olej : MonoBehaviour
{
    public float rotationDuration = 10f;
    private bool isRotating = false;

    private ChangeColor cC;

    void Start()
    {
        cC = GetComponent<ChangeColor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Olejik") && !isRotating)
        {
            StartCoroutine(RotateAroundY(2, rotationDuration));  // Spustí otoèení dvakrát kolem osy Y
        }
    }

    private IEnumerator RotateAroundY(int rotations, float duration)
    {
        isRotating = true;
        float totalRotation = 180 * rotations;  // Celkový úhel otoèení
        float rotationSpeed = totalRotation / duration;  // Rychlost otoèení (stupnì za sekundu)

        float rotated = 0f;
        while (rotated < totalRotation)
        {
            float step = rotationSpeed * Time.deltaTime;  // Výpoèet otoèení v aktuálním frameu
            transform.Rotate(0, step, 0);  // Otoèení kolem osy Y
            rotated += step;
            yield return null;  // Èeká do dalšího framu
        }

        isRotating = false;
        cC.caraO1.SetActive(false);
        cC.caraO2.SetActive(false);
    }
}