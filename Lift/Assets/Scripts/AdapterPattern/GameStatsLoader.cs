using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsLoader {
    private readonly string filePath;

    public GameStatsLoader(string filePath)
    {
        this.filePath = filePath;
    }

    public string LoadStats()
    {
        try
        {
            if (!System.IO.File.Exists(filePath))
            {
                return "No stats available yet.";
            }

            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length <= 1) // Only header or empty
            {
                return "No stats available yet.";
            }

            // Skip the header and take the last 5 entries (or fewer if less exist)
            List<string> statsLines = new List<string>();
            int startIndex = Math.Max(1, lines.Length - 5); // Start from the last 5 entries
            for (int i = startIndex; i < lines.Length; i++)
            {
                statsLines.Add(lines[i]);
            }

            // Format the stats for display (only Date, LiftType, RepsCompleted)
            string displayText = "Recent Stats:\n";
            foreach (string line in statsLines)
            {
                string[] values = line.Split(',');
                if (values.Length >= 3) // Ensure at least 3 columns (Timestamp, Exercise, Reps)
                {
                    displayText += $"{values[0]} - {values[1]}: {values[2]} reps\n";
                }
            }
            return displayText;
        }
        catch (Exception e)
        {
            Debug.LogError($"[GameStatsLoader] Failed to load stats: {e.Message}");
            return "Error loading stats.";
        }
    }
}