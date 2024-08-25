using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class BestTime : MonoBehaviour
{
    public Text TextField;
    public int LvlNum;

    void Start()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Leaderboard_" + LvlNum + ".txt");

        string text = File.ReadAllText(filePath);
        string bestTime = FindBestTime(text);

        TextField.text = bestTime;
    }

    string FindBestTime(string text)
    {
        string pattern = @"(\d{2}):(\d{2}):(\d{2})";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        TimeSpan bestTime = TimeSpan.MaxValue;
        string bestTimeString = null;

        foreach (Match match in matches)
        {
            if (int.TryParse(match.Groups[1].Value, out int minutes) &&
                int.TryParse(match.Groups[2].Value, out int seconds) &&
                int.TryParse(match.Groups[3].Value, out int fractions))
            {
                TimeSpan currentTime = new TimeSpan(0, 0, minutes, seconds, fractions);
                if (currentTime < bestTime)
                {
                    bestTime = currentTime;
                    bestTimeString = $"{minutes:D2}:{seconds:D2}:{fractions:D2}";
                }
            }
        }

        return bestTimeString;
    }
}