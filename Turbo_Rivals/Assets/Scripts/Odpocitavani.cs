using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Odpocitavani : MonoBehaviour
{
    public Canvas CountdownCanvas;
    public Canvas GuiCanvas;
    public Text CountdownText;

    public int Countdown = 3;

    public AudioSource ReadySet;
    public AudioSource Go;

    void Start()
    {
        // Spuštìní coroutine pro odpoèítávání
        StartCoroutine(CountdownCoroutine()); //Korutina v Unity je speciální typ metody, která mùže být asynchronnì spuštìna a provádìna po dobu nìkolika snímkù hry
    }

    private IEnumerator CountdownCoroutine() //rozhraní v jazyce C#, které umožòuje implementovat iterativní operace
    {
        // Zastavení hry
        Time.timeScale = 0f;

        while (Countdown > 0)
        {
            ReadySet.Play();
            CountdownText.text = Countdown.ToString();
            yield return new WaitForSecondsRealtime(1); // Toto klíèové slovo se používá k vrácení hodnoty z korutiny a doèasnému pozastavení jejího bìhu
            Countdown--;
        }

        CountdownText.text = "GO!";
        Go.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);

        // Deaktivace Canvasu po odpoèítávání
        CountdownCanvas.gameObject.SetActive(false);

        GuiCanvas.gameObject.SetActive(true);

        // Obnovení normální rychlosti hry
        Time.timeScale = 1f;
    }
}