using System;
using UnityEngine;

public class CsvFileSaveAdapter : ISaveData {
    private readonly string filePath;
    private bool hasHeader = false;

    public CsvFileSaveAdapter(string filePath)
    {
        this.filePath = filePath;

        // Check if file exists to determine if header is needed
        if (System.IO.File.Exists(filePath))
        {
            hasHeader = true; // Assume header exists if file exists
        }
    }

    public void Save(string data)
    {
        try
        {
            // Add header if file doesn't exist or is new
            if (!hasHeader)
            {
                string header = "Timestamp,Exercise,Reps,LiftTime,Quality";
                System.IO.File.WriteAllText(filePath, header + "\n");
                hasHeader = true;
            }

            // Append the data as a new row
            System.IO.File.AppendAllText(filePath, data + "\n");
            Debug.Log($"[CsvFileSaveAdapter] Saved data to {filePath}: {data}");
        }
        catch (Exception e)
        {
            Debug.LogError($"[CsvFileSaveAdapter] Failed to save data: {e.Message}");
        }
    }
}