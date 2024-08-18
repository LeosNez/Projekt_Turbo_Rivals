using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Odpocitavani : MonoBehaviour
{
    public Canvas countdownCanvas;
    public Canvas guiCanvas;
    public Text countdownText;

    public int countdown = 3;

    public AudioSource readySet;
    public AudioSource go;

    void Start()
    {
        // Spuštìní coroutine pro odpoèítávání
        StartCoroutine(CountdownCoroutine()); //Korutina v Unity je speciální typ metody, která mùže být asynchronnì spuštìna a provádìna po dobu nìkolika snímkù hry
    }

    private IEnumerator CountdownCoroutine() //rozhraní v jazyce C#, které umožòuje implementovat iterativní operace
    {
        // Zastavení hry
        Time.timeScale = 0f;

        while (countdown > 0)
        {
            readySet.Play();
            countdownText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1); // Toto klíèové slovo se používá k vrácení hodnoty z korutiny a doèasnému pozastavení jejího bìhu
            countdown--;
        }

        countdownText.text = "GO!";
        go.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);

        // Deaktivace Canvasu po odpoèítávání
        countdownCanvas.gameObject.SetActive(false);

        guiCanvas.gameObject.SetActive(true);

        // Obnovení normální rychlosti hry
        Time.timeScale = 1f;
    }
}