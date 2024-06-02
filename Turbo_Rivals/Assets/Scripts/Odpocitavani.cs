using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Odpocitavani : MonoBehaviour
{
    public Text countdownText;

    private int countdownTime = 3;

    void Start()
    {
        InvokeRepeating("CountdownTick", 0f, 1f);
    }

    void CountdownTick()
    {
        countdownText.text = countdownTime.ToString();
        countdownTime--;

        if (countdownTime < 0)
        {
            countdownText.text = "GO!";
            // Zastavíme opakování, když dosáhneme nuly.
            CancelInvoke("CountdownTick");

            SceneManager.LoadScene("Level1");
        }
    }
}