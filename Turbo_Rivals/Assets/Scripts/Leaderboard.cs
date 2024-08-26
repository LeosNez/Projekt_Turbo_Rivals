using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text NameTextField;
    public Text TimeTextField;
    public int LvlNum;

    public void Lead()
    {
        // Inicializace seznamu pro ukládání jmen hráèù a jejich èasù
        List<Tuple<string, TimeSpan>> playerTimes = new List<Tuple<string, TimeSpan>>();

        // Cesta k textovému souboru Leaderboardu urèenému pro konkrétní úroveò (lvlNum)
        string filePath = Path.Combine(Application.persistentDataPath, "Leaderboard_" + LvlNum + ".txt");

        // Naètení všech øádkù textového souboru do pole øetìzcù
        string[] lines = File.ReadAllLines(filePath);

        // Regulární výraz pro extrakci jmen a èasù hráèù ve formátu "jméno 00:00:00"
        Regex entryRegex = new Regex(@"(\w+)\s+(\d{2}:\d{2}:\d{2})");

        // Projdi každý øádek textového souboru
        foreach (string line in lines)
        {
            // Pokud øádek odpovídá formátu "jméno 00:00:00"
            Match match = entryRegex.Match(line);
            if (match.Success)
            {
                // Extrahuj jméno hráèe a jeho èas
                string playerName = match.Groups[1].Value;
                string timeString = match.Groups[2].Value;

                // Rozdìlení èasového øetìzce na minuty, sekundy a setiny sekundy
                string[] timeParts = timeString.Split(':');
                if (timeParts.Length == 3 &&
                    int.TryParse(timeParts[0], out int minutes) &&
                    int.TryParse(timeParts[1], out int seconds) &&
                    int.TryParse(timeParts[2], out int miliseconds))
                {
                    // Vytvoøení TimeSpan objektu pro èas hráèe
                    TimeSpan timeSpan = new TimeSpan(0, 0, minutes, seconds, miliseconds);
                    // Pøidání jména hráèe a jeho èasu do seznamu
                    playerTimes.Add(new Tuple<string, TimeSpan>(playerName, timeSpan));
                }
            }
        }

        // Seøazení hráèù podle èasu
        playerTimes = playerTimes.OrderBy(pt => pt.Item2).Take(5).ToList();

        // Vytvoøení seznamu øetìzcù pro zobrazení v textových polích
        List<string> nameEntries = new List<string>();
        List<string> timeEntries = new List<string>();

        foreach (var playerTime in playerTimes)
        {
            // Pøidání jména a èasu hráèe do pøíslušných seznamù
            nameEntries.Add(playerTime.Item1);
            timeEntries.Add($"{playerTime.Item2.Minutes:D2}:{playerTime.Item2.Seconds:D2}:{playerTime.Item2.Milliseconds:D2}");
        }

        // Pøevedení seznamù øetìzcù na jediný øetìzec se znaky nového øádku
        string nameText = string.Join("\n", nameEntries);
        string timeText = string.Join("\n", timeEntries);

        // Zobrazení leaderboardu v textových polích
        NameTextField.text = nameText;
        TimeTextField.text = timeText;
    }
}