using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrechodSceny : MonoBehaviour
{
    public int Scena;

    public void PrejdiNaCilovouScenu()
    {
        SceneManager.LoadScene(Scena);
        Time.timeScale = 1f;
    }
}
