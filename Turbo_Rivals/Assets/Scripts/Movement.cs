using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float zataceni = 100f;
    public float akcelerace = 50f;
    public float maxRychlost = 100f;
    public float couvaciRychlost = 20f;


    public float aktualniRychlost = 0f;
    private float moveInput = 0f;
    private float rotateInput = 0f;

    void Update()
    {
        ReadInput();
        HandleMovement();
    }

    void ReadInput()
    {
        moveInput = 0f;
        rotateInput = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = 1f;
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
        }
        else
        {
            aktualniRychlost += moveInput * couvaciRychlost * Time.deltaTime;
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
        moveInput = -moveInput;
        rotateInput = -rotateInput;
        aktualniRychlost = -aktualniRychlost;
    }
}