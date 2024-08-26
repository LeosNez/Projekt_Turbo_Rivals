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

    public GameObject fire;

    public float minAngle = -45f;
    public float maxAngle = 225f;

    public float zataceni = 50f;
    public float akcelerace = 5f;
    public float maxRychlost = 200f;
    public float couvaciRychlost = 20f;

    public float zataceniDrift = 150f;

    public float turboAcceleration = 100f;
    private bool isTurboActive = false;

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
    private float accBoostDuration = 1.5f;
    public float accBoostTimer = 0f;
    private float originalAcc;

    private Rigidbody rb;

    private ChangeColor cC;

    private Olej o;

    public Transform FrontLeftWheel;
    public Transform FrontRightWheel;
    public float MaxSteerAngle = 30f;
    private float _currentSteerAngle;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cC = GetComponent<ChangeColor>();
        o = GetComponent<Olej>();
    }

    void Update()
    {
        ReadInput();
        HandleMovement();
        Steer();

        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;
            if (speedBoostTimer >= speedBoostDuration)
            {
                maxRychlost = originalMaxSpeed;
                zataceni = originalZataceni;
                isSpeedBoostActive = false;
                minAngle = -45f;
                cC.CaraV1.SetActive(false);
                cC.CaraV2.SetActive(false);
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
        // Převede rychlost na hodnotu mezi 0 a 1
        float normalizedSpeed = Mathf.Clamp01(aktualniRychlost / maxRychlost);
        // Spočítá úhel ručičky na základě normalizedSpeed
        float angle = Mathf.Lerp(maxAngle, minAngle, normalizedSpeed); 
        // Nastaví úhel ručičky tachometru podle vypo
        needle.localRotation = Quaternion.Euler(0f, 0f, angle); //x, y, z
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

        if (Mathf.Abs(aktualniRychlost) > 1.5f)
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            isTurboActive = true;
            fire.gameObject.SetActive(true);
        }
        // Deaktivace turbo
        if (Input.GetKeyUp(KeyCode.T))
        {
            isTurboActive = false;
            fire.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S) && !isTurnBoostActive)
        {
            originalZataceni = zataceni;
            zataceni = originalZataceni;
            zataceni = zataceniDrift;
        }

        if (Input.GetKeyUp(KeyCode.S) && !isTurnBoostActive)
        {
            zataceni = originalZataceni;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            aktualniRychlost = 0f;
            moveInput = 0f;
            rotateInput = 0f;
            cC.CaraV1.SetActive(false);
            cC.CaraV2.SetActive(false);
            cC.CaraO1.SetActive(false);
            cC.CaraO2.SetActive(false);
        }
    }

    public void HandleMovement()
    {
        if (moveInput >= 0)
        {
            if (isTurboActive)
            {
                aktualniRychlost += moveInput * turboAcceleration * Time.deltaTime; // Jízda během turbo
            }
            else
            {
                aktualniRychlost += moveInput * akcelerace * Time.deltaTime; // Normální jízda
            }
            Zpatecka.text = "";
        }
        else
        {
            aktualniRychlost += moveInput * couvaciRychlost * Time.deltaTime; // Couvání
            if (aktualniRychlost < -1)
            {
                Zpatecka.text = "R";
            }
        }
        // Udržuje aktuální rychlost mezi hodnotami maxRaychlost a -maxRychlost
        aktualniRychlost = Mathf.Clamp(aktualniRychlost, -maxRychlost, maxRychlost); 
        // Stará se o pohyb
        transform.Translate(Vector3.forward * aktualniRychlost * Time.deltaTime);
        // Pokud nezrychluje, tak postupně zpomaluje do úplného zastavení
        if (Mathf.Abs(moveInput) < 0.1f)
        {
            aktualniRychlost = Mathf.Lerp(aktualniRychlost, 0f, Time.deltaTime);
        }
        // Zatáčení
        float rotation = rotateInput * zataceni * Time.deltaTime * (aktualniRychlost / maxRychlost);
        transform.Rotate(0, rotation, 0);
    }

    private void Steer()
    {
        _currentSteerAngle = MaxSteerAngle * rotateInput;
        FrontLeftWheel.localRotation = Quaternion.Euler(0, _currentSteerAngle - 90, 0);
        FrontRightWheel.localRotation = Quaternion.Euler(0, _currentSteerAngle - 90, 0);
    }

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Zabrana"))
        {
            aktualniRychlost = aktualniRychlost / 10;
        }

        if (col.gameObject.CompareTag("Pneu"))
        {
            aktualniRychlost = 0f;
        }

        if (col.gameObject.CompareTag("Obstacle"))
        {
            aktualniRychlost = -aktualniRychlost / 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Zpomalení
        if (other.CompareTag("Kaluz") && !isSpeedBoostActive && !isAccBoostActive)
        {
            // Zaznamenat pùvodní maximální rychlost před zpomalením
            originalMaxSpeed = maxRychlost;
            originalZataceni = zataceni;

            zataceni = 200f;
            isSpeedBoostActive = true;
            maxRychlost = 100f;
            speedBoostTimer = 0f;
            minAngle = 90f;
        }

        if (other.CompareTag("Zataceni") && !isTurnBoostActive)
        {
            originalZataceni = zataceni;

            isTurnBoostActive = true;
            zataceni = 40f;
            turnBoostTimer = 0f;
        }

        if (other.CompareTag("Zrychleni") && !isAccBoostActive && !isSpeedBoostActive)
        {
            originalAcc = maxRychlost;

            isAccBoostActive = true;
            maxRychlost = 750f;
            accBoostTimer = 0f;
            aktualniRychlost = maxRychlost;
        }

        if (other.CompareTag("Respawn"))
        {
            aktualniRychlost = 0f;
            moveInput = 0f;
            rotateInput = 0f;
        }
    }
}