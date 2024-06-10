using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Odpocitavani : MonoBehaviour
{
    public Canvas countdownCanvas; // Reference na Canvas pro odpo��t�v�n�
    public Text countdownText; // Reference na Text pro zobrazen� odpo��t�v�n�
    public InputField inputField; // Reference na InputField

    void Start()
    {
        // P�id�n� poslucha�e pro ud�lost "End Edit" InputFieldu
        inputField.onEndEdit.AddListener(delegate { StartCountdown(); });
    }

    public void StartCountdown()
    {
        // Aktivace Canvasu pro odpo��t�v�n�
        countdownCanvas.gameObject.SetActive(true);
        // Spu�t�n� coroutine pro odpo��t�v�n�
        StartCoroutine(CountdownCoroutine()); //Korutina v Unity je speci�ln� typ metody, kter� m��e b�t asynchronn� spu�t�na a prov�d�na po dobu n�kolika sn�mk� hry
    }

    private IEnumerator CountdownCoroutine() //rozhran� v jazyce C#, kter� umo��uje implementovat iterativn� operace
    {
        // Zastaven� hry
        Time.timeScale = 0f;

        int countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1); // Toto kl��ov� slovo se pou��v� k vr�cen� hodnoty z korutiny a do�asn�mu pozastaven� jej�ho b�hu
            countdown--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1);

        // Deaktivace Canvasu po odpo��t�v�n�
        countdownCanvas.gameObject.SetActive(false);

        // Obnoven� norm�ln� rychlosti hry
        Time.timeScale = 1f;
    }
}