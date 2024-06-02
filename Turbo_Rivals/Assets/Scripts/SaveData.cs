using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public Text Cas;

    public void SaveToFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Leaderboard.txt");

        // Otevøení souboru pro zápis
        StreamWriter writer = new StreamWriter(filePath, true);

        // Zápis dat do souboru
        writer.WriteLine(Cas.text);

        // Uzavøení souboru
        writer.Close();

        UnityEngine.Debug.Log("Data byla uložena do souboru: " + filePath);
    }
}
