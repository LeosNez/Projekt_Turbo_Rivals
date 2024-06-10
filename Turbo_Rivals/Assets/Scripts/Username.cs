using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    public InputField uzivatelskeJmeno;
    public GameObject vlozJmeno;
    public GameObject gui;
    public Text jmenoHrace;

    public void JmenoHrace()
    {
        jmenoHrace.text = uzivatelskeJmeno.text;
        vlozJmeno.SetActive(false);
        gui.SetActive(true);
    }
}
