using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform needle;

    public Text Zpatecka;

    public float minAngle = -40f;
    public float maxAngle = 220f;

    public float zataceni = 50f;
    public float akcelerace = 50f;
    public float maxRychlost = 200f;
    public float couvaciRychlost = 20f;

    public float aktualniRychlost = 0f;
    private float moveInput = 0f;
    private float rotateInput = 0f;

    public bool isSpeedBoostActive = false;
    private float speedBoostDuration = 5f;
    public float speedBoostTimer = 0f;
    private float originalMaxSpeed;

    public bool isTurnBoostActive = false;
    private float turnBoostDuration = 5f;
    public float turnBoostTimer = 0f;
    private float originalZataceni;

    public bool isAccBoostActive = false;
    private float accBoostDuration = 3f;
    public float accBoostTimer = 0f;
    private float originalAcc;

    void Update()
    {
        ReadInput();
        HandleMovement();

        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;
            if (speedBoostTimer >= speedBoostDuration)
            {
                maxRychlost = originalMaxSpeed;
                isSpeedBoostActive = false;
            }
        }

        if (isTurnBoostActive)
        {
            turnBoostTimer += Time.deltaTime;
            if (turnBoostTimer >= turnBoostDuration)
            {
                zataceni = originalZataceni;
                isTurnBoostActive = false;
            }
        }

        if (isAccBoostActive)
        {
            accBoostTimer += Time.deltaTime;
            if (accBoostTimer >= accBoostDuration)
            {
                maxRychlost = originalAcc;
                isAccBoostActive = false;
            }
        }

        float normalizedSpeed = Mathf.Clamp01(aktualniRychlost / maxRychlost);
        float angle = Mathf.Lerp(maxAngle, minAngle, normalizedSpeed);

        // Rotate the needle to the calculated angle
        needle.localRotation = Quaternion.Euler(0f, 0f, angle);
    }

    void ReadInput()
    {
        moveInput = 0f;
        rotateInput = 0f;

        if (!isAccBoostActive)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveInput = 1f;
            }
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = -1f;
        }

        if (Mathf.Abs(aktualniRychlost) > 1.5)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotateInput = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotateInput = 1f;
            }
        }
    }

    void HandleMovement()
    {
        if (moveInput >= 0)
        {
            aktualniRychlost += moveInput * akcelerace * Time.deltaTime;
            Zpatecka.text = "";
        }
        else
        {
            aktualniRychlost += moveInput * couvaciRychlost * Time.deltaTime;
            Zpatecka.text = "R";
        }

        aktualniRychlost = Mathf.Clamp(aktualniRychlost, -maxRychlost, maxRychlost); //  Tato funkce se stará o to, že první hodnota zùstane mezi druhou a tøetí hodnotou kde druhá je min a tøetí je max

        transform.Translate(Vector3.forward * aktualniRychlost * Time.deltaTime); // Stará se o pohyb

        if (Mathf.Abs(moveInput) < 0.1f)
        {
            aktualniRychlost = Mathf.Lerp(aktualniRychlost, 0f, Time.deltaTime); // Postupné zpomalování. Lerp se stará o plynulý pohyb. první v závorce je poèáteèní hodnota, v druhé hodnota na kterou se chceme dostat. Poslední zajišuje plynulý pohyb
        }

        float rotation = rotateInput * zataceni * Time.deltaTime; // Nastavení rotace objektu pøi zatáèení
        transform.Rotate(Vector3.up * rotation); // objekt se bude otáèeet po ose Y na základì rotace
    }

    private void OnCollisionEnter(Collision col)
    {
        moveInput = -moveInput / 3;
        rotateInput = -rotateInput / 3;
        aktualniRychlost = -aktualniRychlost / 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Zpomalení
        if (other.CompareTag("Kaluz") && !isSpeedBoostActive && !isAccBoostActive)
        {
            // Zaznamenat pùvodní maximální rychlost pøed zpomalením
            originalMaxSpeed = maxRychlost;

            isSpeedBoostActive = true;
            maxRychlost = 100f;
            speedBoostTimer = 0f;
        }

        if (other.CompareTag("Zataceni") && !isTurnBoostActive)
        {
            originalZataceni = zataceni;

            isTurnBoostActive = true;
            zataceni = 25f;
            turnBoostTimer = 0f;
        }

        if (other.CompareTag("Zrychleni") && !isAccBoostActive && !isSpeedBoostActive)
        {
            originalAcc = maxRychlost;

            isAccBoostActive = true;
            maxRychlost = 1000f;
            accBoostTimer = 0f;
            aktualniRychlost = maxRychlost;
        }
    }
}