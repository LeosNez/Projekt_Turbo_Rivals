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
        // Application.persistentDataPath poskytuje cestu k �lo�i�ti aplikace
        // Path.Combine bezpe�n� sestav� cestu z r�zn�ch ��st�, aby se p�ede�lo probl�m�m s form�tov�n�m cesty
        string filePath = Path.Combine(Application.persistentDataPath, "Leaderboard_" + LvlNum + ".txt");

        // Otev�en� souboru pro z�pis
        //true znamen�, �e data budou do souboru p�id�v�na
        StreamWriter writer = new StreamWriter(filePath, true);

        // Z�pis dat do souboru
        writer.WriteLine(Jmeno.text + " " + Cas.text);

        // Uzav�en� souboru
        writer.Close();

        UnityEngine.Debug.Log("Data byla ulo�ena do souboru: " + filePath);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveToFile();
        }
    }
}
