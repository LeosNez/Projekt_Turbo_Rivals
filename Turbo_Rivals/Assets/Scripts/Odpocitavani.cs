using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Odpocitavani : MonoBehaviour
{
    public Canvas countdownCanvas; // Reference na Canvas pro odpoèítávání
    public Text countdownText; // Reference na Text pro zobrazení odpoèítávání
    public InputField inputField; // Reference na InputField

    void Start()
    {
        // Pøidání posluchaèe pro událost "End Edit" InputFieldu
        inputField.onEndEdit.AddListener(delegate { StartCountdown(); });
    }

    public void StartCountdown()
    {
        // Aktivace Canvasu pro odpoèítávání
        countdownCanvas.gameObject.SetActive(true);
        // Spuštìní coroutine pro odpoèítávání
        StartCoroutine(CountdownCoroutine()); //Korutina v Unity je speciální typ metody, která mùže být asynchronnì spuštìna a provádìna po dobu nìkolika snímkù hry
    }

    private IEnumerator CountdownCoroutine() //rozhraní v jazyce C#, které umožòuje implementovat iterativní operace
    {
        // Zastavení hry
        Time.timeScale = 0f;

        int countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1); // Toto klíèové slovo se používá k vrácení hodnoty z korutiny a doèasnému pozastavení jejího bìhu
            countdown--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1);

        // Deaktivace Canvasu po odpoèítávání
        countdownCanvas.gameObject.SetActive(false);

        // Obnovení normální rychlosti hry
        Time.timeScale = 1f;
    }
}