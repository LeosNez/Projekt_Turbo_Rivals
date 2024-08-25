using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public Text Cas;
    public Text Jmeno;
    public int LvlNum;

    public void SaveToFile()
    {
        // Application.persistentDataPath poskytuje cestu k úložišti aplikace
        // Path.Combine bezpeènì sestaví cestu z rùzných èástí, aby se pøedešlo problémùm s formátováním cesty
        string filePath = Path.Combine(Application.persistentDataPath, "Leaderboard_" + LvlNum + ".txt");

        // Otevøení souboru pro zápis
        //true znamená, že data budou do souboru pøidávána
        StreamWriter writer = new StreamWriter(filePath, true);

        // Zápis dat do souboru
        writer.WriteLine(Jmeno.text + " " + Cas.text);

        // Uzavøení souboru
        writer.Close();

        UnityEngine.Debug.Log("Data byla uložena do souboru: " + filePath);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveToFile();
        }
    }
}
